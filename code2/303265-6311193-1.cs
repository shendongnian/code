    using System;
    using NGit;
    using NGit.Api;
    using NGit.Transport;
    namespace Stacko
    {
        class MainClass
        {
            public static void Main (string[] args)
            {
                Git myrepo = Git.Init().SetDirectory(@"/tmp/myrepo.git").SetBare(true).Call();
                {
                    var fetchResult = myrepo.Fetch()
                        .SetProgressMonitor(new TextProgressMonitor())
                        .SetRemote(@"/tmp/initial")
                        .SetRefSpecs(new RefSpec("refs/heads/master:refs/heads/master"))
                        .Call();
                    //
                    // Some other work...
                    //
                    myrepo.GetRepository().Close();
                }
                System.GC.Collect();
    #if false
                System.Console.WriteLine("Killing");
                BatchingProgressMonitor.ShutdownNow();
    #endif
                System.Console.WriteLine("Done");
            }
        }
    }
