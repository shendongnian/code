                        else
                        {
                            if (HasApplicableConditionalMethod(resolution.OverloadResolutionResult))
                            {
                                // warning CS1974: The dynamically dispatched call to method 'Goo' may fail at runtime
                                // because one or more applicable overloads are conditional methods
                                Error(diagnostics, ErrorCode.WRN_DynamicDispatchToConditionalMethod, syntax, methodGroup.Name);
                            }
                            // Note that the runtime binder may consider candidates that haven't passed compile-time final validation 
                            // and an ambiguity error may be reported. Also additional checks are performed in runtime final validation 
                            // that are not performed at compile-time.
                            // Only if the set of final applicable candidates is empty we know for sure the call will fail at runtime.
                            var finalApplicableCandidates = GetCandidatesPassingFinalValidation(syntax, resolution.OverloadResolutionResult,
                                                                                                methodGroup.ReceiverOpt,
                                                                                                methodGroup.TypeArgumentsOpt,
                                                                                                diagnostics);
                            if (finalApplicableCandidates.Length > 0)
                            {
                                result = BindDynamicInvocation(syntax, methodGroup, resolution.AnalyzedArguments, finalApplicableCandidates, diagnostics, queryClause);
                            }
                            else
                            {
                                result = CreateBadCall(syntax, methodGroup, methodGroup.ResultKind, analyzedArguments);
                            }
