    List<Microsoft.ML.Data.TextLoader.Column> mlCols = new List<Microsoft.ML.Data.TextLoader.Column>();
	mlCols.Add(new Microsoft.ML.Data.TextLoader.Column("PCH_RECFAC_09_14", Microsoft.ML.Data.DataKind.Single, 0));
	mlCols.Add(new Microsoft.ML.Data.TextLoader.Column("PCH_RECFACPTH_09_14", Microsoft.ML.Data.DataKind.Single, 1));
	mlCols.Add(new Microsoft.ML.Data.TextLoader.Column("PCT_DIABETES_ADULTS08", Microsoft.ML.Data.DataKind.Single, 2));
	mlCols.Add(new Microsoft.ML.Data.TextLoader.Column("State", Microsoft.ML.Data.DataKind.String, 3));
	mlCols.Add(new Microsoft.ML.Data.TextLoader.Column("PCT_DIABETES_ADULTS13", Microsoft.ML.Data.DataKind.Single, 4));
	IDataView trainingDataView = mlContext.Data.LoadFromTextFile(fileLocTraining, mlCols.ToArray(),
																 ',', true, true, true, false);
