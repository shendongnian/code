            currentTableName = tConParamTables.SelectedTab.Name;
            string colName = "", colValue = "", colValueList = "", colNameList = "";
            txtBoxCreate = insertTxtBoxList[0];
            colNameList = commaSepCols[0];
            colValueList = txtBoxCreate.Text;
            for (int i = 1; i < numberOfCols; i++)
            {
                txtBoxCreate = insertTxtBoxList[i];
                colName = commaSepCols[i];
                colValue = txtBoxCreate.Text;
                colNameList = colNameList + "," + colName;
                colValueList = colValueList + "'" + "," + "'" + colValue;
            }
            InsertParamTables(_DBCONN, currentTableName, colNameList, colValueList);
            selectLastRow();
            createForm.Dispose();
