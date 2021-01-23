        public int DbNumRecs(string file) {
            if (!File.Exists(file)) {
                return -1;
            }
            // don't need to use AppDomain
            COMMONIDEACONTROLSLib db = null; // don't need to initialize class here
            try {
                db = objApp.OpenDatabase(file);
                return (int)db.Count;
            } catch (Exception) } // don't need to declare unused ex variable
                return -1;
            } finally {
                try {
                    if (db != null) {
                        db.Close();
                        Marshal.ReleaseComObject(db);
                    }
                    objApp.CloseDatabase(file); // is this line really needed?
                } catch (Exception) {} // silently ignore exceptions when closing
            }
        }
