    var conversationQABySubjectId = _repoWrapper.ConversationQuestionAnswer.FindAll()
                                            .Where(a => a.SubjectId == subjectId)
                                            .GroupJoin(_repoWrapper.ContactInformation.FindAll(),
                                            c => c.ResponderContactInformationIdentifier,
                                            ci => ci.ContactInformationIdentifier,
                                            (c, ci) => new { c, ci })
                                            .SelectMany(m => m.ci.DefaultIfEmpty(), (m,n) => new Tuple<Domain.TC_Context.ConversationQuestionAnswer,
                                                                   Domain.TC_Context.ContactInformation>(m.c, n));
