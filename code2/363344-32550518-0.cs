    private void SetGridColumns(ref RegistryKey targetKey, List<ColInfo> cols)
        {
            string targetKeyName = Path.GetFileName(targetKey.Name);
            m_grids.DeleteSubKeyTree(targetKeyName, false);
            targetKey.Close();
            targetKey = m_grids.CreateSubKey(targetKeyName);
//...
        }
        public void SetColumns(List<ColInfo> cols, bool youth)
        {
            RegistryKey key = youth ? m_youthGrid : m_mainGrid;
            SetGridColumns(ref key, cols);
        }
