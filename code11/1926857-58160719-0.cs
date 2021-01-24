    publicstaticvoidUpdateResult()
            {
    
                TfsTeamProjectCollectiontfs = newTfsTeamProjectCollection(TfsTeamProjectCollection.GetFullyQualifiedUriForName(server));
                ITestManagementServicetms = tfs.GetService<ITestManagementService>();
                ITestManagementTeamProjectproj = tms.GetTeamProject(project);
                ITestPlanPlan = proj.TestPlans.Find(1);
    IStaticTestSuitesuite = Plan.RootSuite.SubSuites.Where(s => s.Id == 1339).First() asIStaticTestSuite;
                ITestCasetestcase = null;
                testcase = suite.Entries.Where(e => e.Title == "login").First().TestCase;
                ITestRuntestRun = project.TestRuns.Create();
                testRun = Plan.CreateTestRun(false); 
                
                ITestPointCollectionpoints = Plan.QueryTestPoints("SELECT * FROM TestPoint WHERE TestCaseId ="+ testcase.Id);
                foreach(ITestPointp inpoints)
                {
    
                    testRun.AddTestPoint(p, Plan.Owner);// null);
                    //testRun.AddTestPoint(p, null);
    
                }
                testRun.State = TestRunState.Completed;
                testRun.Save();
                
                ITestCaseResultCollectionresults = testRun.QueryResults();
                ITestIterationResultiterationResult;
                foreach(ITestCaseResultresult inresults)
                {
                    iterationResult = result.CreateIteration(1);
                    foreach(ITestSteptestStep inresult.GetTestCase().Actions)
                    {
                        ITestStepResultstepResult = iterationResult.CreateStepResult(testStep.Id);
                        stepResult.Outcome = TestOutcome.Passed;                        
                        iterationResult.Actions.Add(stepResult);
                       
                    }
                    iterationResult.Outcome = TestOutcome.Passed;
                    result.Iterations.Add(iterationResult);
                    result.Outcome = TestOutcome.Passed;
                    result.State = TestResultState.Completed;
                    result.Save(true);
    
                }
                testRun.Save();
                testRun.Refresh();
    
            }
