    namespace SampleRunCreation
    {
        class Program
        {
            static void Main(string[] args)
            {
                TfsTeamProjectCollection tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri("http://pradeepn-tcm:8080/tfs/DefaultCollection"));
                ITestManagementTeamProject project = tfs.GetService<ITestManagementService>().GetTeamProject("Pradeep");
    
                // Create a test case.
                ITestCase testCase = CreateTestCase(project, "My test case");
    
                // Create test plan.
                ITestPlan plan = CreateTestPlan(project, "My test plan");
    
                // Create test configuration. You can reuse this instead of creating a new config everytime.
                ITestConfiguration config = CreateTestConfiguration(project, string.Format("My test config {0}", DateTime.Now));
    
                // Create test points. 
                IList<ITestPoint> testPoints = CreateTestPoints(project,
                                                                plan,
                                                                new List<ITestCase>(){testCase}, 
                                                                new IdAndName[] { new IdAndName(config.Id, config.Name) });
    
                // Create test run using test points.
                ITestRun run = CreateTestRun(project, plan, testPoints);
    
                // Query results from the run.
                ITestCaseResult result = run.QueryResults()[0];
    
                // Fail the result.
                result.Outcome = TestOutcome.Failed;
                result.State = TestResultState.Completed;
                result.Save();
    
                Console.WriteLine("Run {0} completed", run.Id);
            }
    
            private static ITestCase CreateTestCase(ITestManagementTeamProject project,
                                                    string title)
            {
                // Create a test case.
                ITestCase testCase = project.TestCases.Create();
                testCase.Owner = null;
                testCase.Title = title;
                testCase.Save();
                return testCase;
            }
    
            private static ITestPlan CreateTestPlan(ITestManagementTeamProject project, string title)
            {
                // Create a test plan.
                ITestPlan testPlan = project.TestPlans.Create();
                testPlan.Name = title;
                testPlan.Save();
                return testPlan;
            }
    
            private static ITestConfiguration CreateTestConfiguration(ITestManagementTeamProject project, string title)
            {
                ITestConfiguration configuration = project.TestConfigurations.Create();
                configuration.Name = title;
                configuration.Description = "DefaultConfig";
                configuration.Values.Add(new KeyValuePair<string, string>("Browser", "IE"));
                configuration.Save();
                return configuration;
            }
    
            public static IList<ITestPoint> CreateTestPoints(ITestManagementTeamProject project,
                                                             ITestPlan testPlan, 
                                                             IList<ITestCase> testCases, 
                                                             IList<IdAndName> testConfigs)
            {
                // Create a static suite within the plan and add all the test cases.
                IStaticTestSuite testSuite = CreateTestSuite(project);
                testPlan.RootSuite.Entries.Add(testSuite);
                testPlan.Save();
    
                testSuite.Entries.AddCases(testCases);
                testPlan.Save();
    
                testSuite.SetEntryConfigurations(testSuite.Entries, testConfigs);
                testPlan.Save();
    
                ITestPointCollection tpc = testPlan.QueryTestPoints("SELECT * FROM TestPoint WHERE SuiteId = " + testSuite.Id);
                return new List<ITestPoint>(tpc);
            }
    
            private static IStaticTestSuite CreateTestSuite(ITestManagementTeamProject project)
            {
                // Create a static test suite.
                IStaticTestSuite testSuite = project.TestSuites.CreateStatic();
                testSuite.Title = "Static Suite";
                return testSuite;
            }
    
            private static ITestRun CreateTestRun(ITestManagementTeamProject project,
                                                 ITestPlan plan,
                                                 IList<ITestPoint> points)
            {
                ITestRun run = plan.CreateTestRun(false);
                foreach (ITestPoint tp in points)
                {
                    run.AddTestPoint(tp, null);
                }
    
                run.Save();
                return run;
            }
        }
    }
