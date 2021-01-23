        void GetVersions(string sourcefile)
        {
            ClearCase.CCElement element = m_CC.get_Element(sourcefile);
            if (element != null)
            {
                ClearCase.CCVersion latestVersion = null;
                FileInfo fi = new FileInfo(sourcefile);
                latestVersion = element.get_Version();
               if (latestVersion != null)
                {
                    ClearCase.CCBranch branch = latestVersion.Branch;
                    ClearCase.CCCheckedOutFile file = latestVersion.CheckOut(ClearCase.CCReservedState.ccReserved, "", false, ClearCase.CCVersionToCheckOut.ccVersion_SpecificVersion, true, false);
                    string path = file.ExtendedPath;
                }
            }
        }
        void checkIn(string sourcefile)
        {
            ClearCase.CCElement element = m_CC.get_Element(sourcefile);
            element.CheckedOutFile.CheckIn("", true, sourcefile, ClearCase.CCKeepState.ccKeep);
        }
