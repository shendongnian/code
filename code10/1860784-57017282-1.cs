    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Security;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualBasic;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Web.UI;
    
    public static class UserStates
    {
        public static int CurrSessionVariableIndex
        {
            get
            {
                int I;
                if (LDB.CustomData.TryGetValue("CurrSessionIndex", I))
                    return I;
                else
                {
                    LDB.CustomData("CurrSessionIndex") = 1;
                    return I;
                }
            }
            set
            {
                LDB.CustomData("CurrSessionIndex") = value;
            }
        }
    
        public static int NewSessionVariableIndex()
        {
            CurrSessionVariableIndex += 1;
            return CurrSessionVariableIndex;
        }
    
    
        public static bool PreferMemoryMapFiles = true;
    
    
    
    
        public static Dictionary<int, Dictionary<string, object>> ViewStatusBags = new Dictionary<int, Dictionary<string, object>>(300);
        public static Dictionary<int, DateTime> ViewStatusTimes = new Dictionary<int, DateTime>(300);
    
        public static void SetViewVarRAM(int ViewStateID, string key, object Obj)
        {
            Dictionary<string, object> Bag = null;
            if (ViewStatusBags.TryGetValue(ViewStateID, out Bag))
            {
                try
                {
                    Bag[key] = Obj;
                }
                catch (Exception ex)
                {
                    Log($"Added new ViewBag.Var {ViewStateID}.{key}");
                    Bag.Add(key, Obj);
                }
                ViewStatusTimes[ViewStateID] = DateTime.Now;
            }
            else
            {
                Log($"Added new ViewBag {ViewStateID}");
                Bag = new Dictionary<string, object>();
                ViewStatusBags.Add(ViewStateID, Bag);
                ViewStatusTimes.Add(ViewStateID, DateTime.Now);
                Bag.Add(key, Obj);
            }
        }
    
        public static object GetViewVarRAM(int ViewStateID, string key)
        {
            Dictionary<string, object> Bag = null;
            if (ViewStatusBags.TryGetValue(ViewStateID, out Bag))
            {
                ViewStatusTimes[ViewStateID] = DateTime.Now;
                try
                {
                    return Bag[key];
                }
                catch (Exception ex)
                {
                    Log($"Added new ViewBag.Var {ViewStateID}.{key}");
                    Bag.Add(key, null);
                    return Bag[key];
                }
            }
            else
            {
                Log($"Added new ViewBag {ViewStateID}");
                Bag = new Dictionary<string, object>();
                ViewStatusBags.Add(ViewStateID, Bag);
                ViewStatusTimes.Add(ViewStateID, DateTime.Now);
    
                Bag.Add(key, null);
                return Bag[key];
            }
        }
    
    
    
        public static Dictionary<string, object> GetViewMMF(int ViewStateID)
        {
            FileStream FS = null;
            BinaryFormatter BF = new BinaryFormatter();
    
            GetFileStream(ref ViewStateID, ref FS);
    
    
    
            Dictionary<string, object> Bag;
    
            try
            {
                Bag = BF.Deserialize(FS);
            }
            catch (Exception ex)
            {
                if (!ex.Message.StartsWith("Attempting to deserialize an empty stream"))
                    LogError(ex, $"@MMF.Get : cannot Deserialize FS {ViewStateID}");
                FS.Flush();
                Bag = new Dictionary<string, object>();
                SetViewMMF(ViewStateID, Bag);
            }
    
            try
            {
                FS.Flush();
            }
            catch (Exception ex)
            {
            }
    
            return Bag;
        }
    
        public static void SetViewMMF(int ViewStateID, Dictionary<string, object> Bag)
        {
            FileStream FS = null;
            BinaryFormatter BF = new BinaryFormatter();
    
    
            GetFileStream(ref ViewStateID, ref FS);
    
    
            try
            {
                BF.Serialize(FS, Bag);
            }
            catch (Exception ex)
            {
                LogError(ex, $"@MMF.Set : cannot Serialize FS {ViewStateID}");
                FS.Flush();
            }
    
            try
            {
                FS.Flush();
            }
            catch (Exception ex)
            {
            }
        }
    
    
    
        public static Dictionary<int, FileStream> MMFStreams = new Dictionary<int, FileStream>(100);
        public static Dictionary<int, DateTime> MMFStreamsTimes = new Dictionary<int, DateTime>(100);
        public static string FilePathMMFs;
    
        private static void GetFileStream(ref int ViewStateID, ref FileStream FS)
        {
            if (MMFStreams.TryGetValue(ViewStateID, out FS))
            {
                try
                {
                    FS.Seek(0, SeekOrigin.Begin);
                }
                catch (Exception ex)
                {
                    LogError(ex, $"@MMF.Set : cannot restart FS {ViewStateID}");
                    FS = new FileStream(FilePathMMFs + ViewStateID.ToString() + "-" + Rand.Next(100, 1000).ToString, FileMode.OpenOrCreate);
                    FS.Seek(0, SeekOrigin.Begin);
                    MMFStreams[ViewStateID] = FS;
                }
    
                MMFStreamsTimes[ViewStateID] = DateTime.Now;
            }
            else
            {
                try
                {
                    FS = new FileStream(FilePathMMFs + ViewStateID.ToString(), FileMode.OpenOrCreate);
                    FS.Seek(0, SeekOrigin.Begin);
                    MMFStreams.Add(ViewStateID, FS);
                }
                catch (Exception ex)
                {
                    LogError(ex, $"@MMF.Set : cannot OpenOrCreate new FS {ViewStateID}");
                    FS = new FileStream(FilePathMMFs + ViewStateID.ToString() + "-" + Rand.Next(100, 1000).ToString, FileMode.OpenOrCreate);
                    FS.Seek(0, SeekOrigin.Begin);
                    MMFStreams.Add(ViewStateID, FS);
                }
    
                MMFStreamsTimes[ViewStateID] = DateTime.Now;
            }
        }
    
    
    
    
    
    
    
    
        public static void SetViewVarMMF(int ViewStateID, string key, object Obj)
        {
            FileStream FS = null;
            BinaryFormatter BF = new BinaryFormatter();
    
            GetFileStream(ref ViewStateID, ref FS);
            Dictionary<string, object> Bag;
    
            try
            {
                Bag = BF.Deserialize(FS);
            }
            catch (Exception ex)
            {
                // LogError(ex, $"@MMF.SetViewVarMMF : cannot Deserialize FS {ViewStateID}. saved new bag")
                Bag = new Dictionary<string, object>();
            }
    
            FS.Seek(0, SeekOrigin.Begin);
    
            if (Bag.ContainsKey(key))
                Bag[key] = Obj;
            else
                Bag.Add(key, Obj);
    
    
            try
            {
                BF.Serialize(FS, Bag);
            }
            catch (Exception ex)
            {
                LogError(ex, $"@MMF.SetViewVarMMF : cannot Serialize FS {ViewStateID}");
                FS.Flush();
            }
    
            try
            {
                FS.Flush();
            }
            catch (Exception ex)
            {
            }
        }
    
    
    
        public static object GetViewVarMMF(int ViewStateID, string key)
        {
            var Bag = GetViewMMF(ViewStateID);
    
            object Obj = null;
            if (Bag.TryGetValue(key, out Obj))
                return Obj;
            else
                return null;
    
            Bag = null;
        }
    
    
    
    
    
    
        public static Dictionary<int, UserContainer> AllUserContainer = new Dictionary<int, UserContainer>(50);
    
    
    
        public static void SetUserContainer(int Usr, UserContainer Con)
        {
            Con.UserID = Usr;
            if (AllUserContainer.ContainsKey(Usr))
            {
                AllUserContainer[Usr] = Con;
                Con.Time = DateTime.Now;
            }
            else
            {
                Log($"Added new user {Usr}");
                AllUserContainer.Add(Usr, Con);
                Con.Time = DateTime.Now;
            }
        }
    
        public static UserContainer GetUserContainer(int Usr)
        {
            UserContainer Con = null/* TODO Change to default(_) if this is not a reference type */;
    
            if (AllUserContainer.TryGetValue(Usr, out Con))
            {
                Con.Time = DateTime.Now;
                return Con;
            }
            else
            {
                Log($"Added new user {Usr}");
                Con = new UserContainer(Usr);
                AllUserContainer.Add(Usr, Con);
                Con.Time = DateTime.Now;
                return Con;
            }
        }
    
    
    
    
    
        // ___________________________________________________'
    
    
        public static void SetViewVar(int ViewStateID, string key, object Obj)
        {
            if (PreferMemoryMapFiles)
                SetViewVarMMF(ViewStateID, key, Obj);
            else
                SetViewVarRAM(ViewStateID, key, Obj);
        }
    
    
    
    
        public static object GetViewVar(int ViewStateID, string key)
        {
            if (PreferMemoryMapFiles)
                return GetViewVarMMF(ViewStateID, key);
            else
                return GetViewVarRAM(ViewStateID, key);
        }
    
    
        public static void RemoveMMF(int ViewStateID)
        {
            FileStream FS = null;
    
            if (MMFStreams.TryGetValue(ViewStateID, out FS))
            {
                try
                {
                    FS.Close();
                }
                catch (Exception ex)
                {
                }
            }
        }
    
        public static void RemoveUserContainer(int Usr)
        {
            if (AllUserContainer.ContainsKey(Usr))
            {
                AllUserContainer[Usr].Dispose();
                AllUserContainer.Remove(Usr);
                Log($"Removed user {Usr}");
            }
        }
    
    
    
        public static void DeleteUnusedMMFs()
        {
            var Files = Directory.GetFiles(FilePathMMFs);
    
            DateTime nowTime = DateTime.Now;
    
            var nOfFiles = 0;
    
            foreach (var FilePath in Files)
            {
                var FileID = Path.GetFileName(FilePath);
    
                DateTime Time = DateTime.MinValue;
                if (UserStates.MMFStreamsTimes.TryGetValue(FileID, out Time))
                {
                    if (Time.AddMinutes(5) < nowTime)
                    {
                        try
                        {
                            UserStates.MMFStreams[FileID].Close();
                        }
                        catch (Exception ex)
                        {
                        }
                        try
                        {
                            File.Delete(FilePath);
                            nOfFiles += 1;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else
                    try
                    {
                        File.Delete(FilePath);
                        nOfFiles += 1;
                    }
                    catch (Exception ex)
                    {
                    }
            }
    
    
            Log($"@ViewStates.DeleteUnusedMMFs : {nOfFiles} deleted");
        }
    
    
        // ___________________________________________________'
    
    
        public static void ClearUnusedViewStates()
        {
            var BeforeRAM = (My.Application.Info.WorkingSet / (double)1024) / (double)1024;
    
            var CurrTime = DateTime.Now;
    
            List<int> ToRemove = new List<int>();
            int ViewEntries;
            int UsrEntries;
    
            if (ViewStatusBags.Count == 0)
                goto RemoveusrsLbl;
    
            for (var i = ViewStatusBags.Count - 1; i >= 0; i += -1)
            {
                var Time = ViewStatusTimes.ElementAt(i).Value;
    
                if (Time.AddMinutes(5) < CurrTime)
                    ToRemove.Add(ViewStatusBags.ElementAt(i).Key);
            }
    
            ViewEntries = ToRemove.Count;
            foreach (var i in ToRemove)
                ViewStatusBags.Remove(i);
    
    
            RemoveusrsLbl:
            ;
            if (AllUserContainer.Count == 0)
                goto Final;
    
            for (var i = AllUserContainer.Count - 1; i >= 0; i += -1)
            {
                if (AllUserContainer[i].Time.AddMinutes(15) < CurrTime)
                {
                    AllUserContainer.Remove(AllUserContainer[i].UserID);
                    UsrEntries += 1;
                }
            }
    
    
    
        Final:
            ;
            GC.Collect();
    
    
            var AfterRAM = (My.Application.Info.WorkingSet / (double)1024) / (double)1024;
    
    
            Log($"@ViewStates : {ViewEntries} Unused ViewStates Cleared. {UsrEntries} inactive users cleared. {AfterRAM - BeforeRAM} MB Cleared. ");
        }
    }
  
