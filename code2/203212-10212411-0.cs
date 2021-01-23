    public static void documentsMerge(object fileName, List<string> arrayList) {
            bool varTest = deleteFile(fileName.ToString());
            if (varTest)
            {
                using (DocX documentToCreate = DocX.Load(arrayList[0]))
                {
                    foreach (var alItem in arrayList.Skip(1))
                    {
                        documentToCreate.InsertParagraph().InsertPageBreakAfterSelf();
                        DocX documentToMergeIn = DocX.Load(alItem);
                        documentToCreate.InsertDocument(documentToMergeIn);
                    }
                    documentToCreate.SaveAs(fileName.ToString());
                }
            }
        }
