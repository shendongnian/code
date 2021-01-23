    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using EnvDTE80;
    using EnvDTE;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    [TestClass]
    public class ProjectSettingsTest
    {
        /// <summary>
        /// Tests that the platform for Mixed Platforms and Any CPU configurations 
        /// is Any CPU for all projects of this solution
        /// </summary>
        [TestMethod]
        public void TestReleaseBuildIsAnyCPU()
        {
            MessageFilter.Register();
            
            DTE2 dte2 = GetCurrent();
            Assert.IsNotNull(dte2);
            foreach (SolutionConfiguration2 config in dte2.Solution.SolutionBuild.SolutionConfigurations)
            {
                if (config.PlatformName.Contains("Mixed Platforms") || config.PlatformName.Contains("Any CPU"))
                {
                    foreach (SolutionContext context in config.SolutionContexts)
                        Assert.AreEqual("Any CPU", context.PlatformName, string.Format("{0} is configured {1} in {2}/{3}", context.ProjectName, context.PlatformName, config.PlatformName, config.Name));
                }
            }
            
            MessageFilter.Revoke();
        }
        [DllImport("ole32.dll")]
        private static extern void CreateBindCtx(int reserved, out IBindCtx ppbc);
        [DllImport("ole32.dll")]
        private static extern void GetRunningObjectTable(int reserved, out IRunningObjectTable prot);
        /// <summary>
        /// Gets the current visual studio's solution DTE2
        /// </summary>
        public static DTE2 GetCurrent()
        {
            List<DTE2> dte2s = new List<DTE2>();
            IRunningObjectTable rot;
            GetRunningObjectTable(0, out rot);
            IEnumMoniker enumMoniker;
            rot.EnumRunning(out enumMoniker);
            enumMoniker.Reset();
            IntPtr fetched = IntPtr.Zero;
            IMoniker[] moniker = new IMoniker[1];
            while (enumMoniker.Next(1, moniker, fetched) == 0)
            {
                IBindCtx bindCtx;
                CreateBindCtx(0, out bindCtx);
                string displayName;
                moniker[0].GetDisplayName(bindCtx, null, out displayName);
                // add all VisualStudio ROT entries to list
                if (displayName.StartsWith("!VisualStudio"))
                {
                    object comObject;
                    rot.GetObject(moniker[0], out comObject);
                    dte2s.Add((DTE2)comObject);
                }
            }
            // get path of the executing assembly (assembly that holds this code) - you may need to adapt that to your setup
            string thisPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            // compare dte solution paths to find best match
            KeyValuePair<DTE2, int> maxMatch = new KeyValuePair<DTE2, int>(null, 0);
            foreach (DTE2 dte2 in dte2s)
            {
                int matching = GetMatchingCharsFromStart(thisPath, dte2.Solution.FullName);
                if (matching > maxMatch.Value)
                    maxMatch = new KeyValuePair<DTE2, int>(dte2, matching);
            }
            return (DTE2)maxMatch.Key;
        }
        /// <summary>
        /// Gets index of first non-equal char for two strings
        /// Not case sensitive.
        /// </summary>
        private static int GetMatchingCharsFromStart(string a, string b)
        {
            a = (a ?? string.Empty).ToLower();
            b = (b ?? string.Empty).ToLower();
            int matching = 0;
            for (int i = 0; i < Math.Min(a.Length, b.Length); i++)
            {
                if (!char.Equals(a[i], b[i]))
                    break;
                matching++;
            }
            return matching;
        }
    }
