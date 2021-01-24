        private void SetupFieldMapping(ReleaseData documentData)
        {
            Dictionary<string, string> indexFields = new Dictionary<string, string>();
            Dictionary<string, string> batchFields = new Dictionary<string, string>();
            Dictionary<string, string> kofaxValues = new Dictionary<string, string>();
            foreach (Value val in documentData.Values)
            {
                string tableName = val.TableName;
                bool relatedToTable = tableName != string.Empty;
                string sourceName = val.SourceName;
                string sourceValue = val.Value;
                KfxLinkSourceType sourceType = val.SourceType;
                if (relatedToTable)
                {
                    string[] columnValues = sourceValue.Split(';');
                    // sourceName is the key of the subitem from the table
                    // columnValues => values from all rows at the column "sourceName"
                    // do stuff
                }
                else
                {
                    switch (val.SourceType)
                    {
                        case KfxLinkSourceType.KFX_REL_INDEXFIELD:
                            indexFields.Add(sourceName, sourceValue);
                            break;
                        case KfxLinkSourceType.KFX_REL_VARIABLE:
                            kofaxValues.Add(sourceName, sourceValue);
                            break;
                        case KfxLinkSourceType.KFX_REL_BATCHFIELD:
                            batchFields.Add(sourceName, sourceValue);
                            break;
                    }
                }
            }
        }
