	private static Run CreateSimpleTextRun(string text)
	{
		Run returnVar = new Run();
		RunProperties runProp = new RunProperties();
		runProp.Append(new NoProof());
		returnVar.Append(runProp);
		returnVar.Append(new Text() { Text = text });
		return returnVar;
	}
	private static void InsertMergeFieldText(OpenXmlElement field, string replacementText)
	{
		var sf = field as SimpleField;
		if (sf != null)
		{
			var textChildren = sf.Descendants<Text>();
			textChildren.First().Text = replacementText;
			foreach (var others in textChildren.Skip(1))
			{
				others.Remove();
			}
		}
		else
		{
			var runs = GetAssociatedRuns((FieldCode)field);
			var rEnd = runs[runs.Count - 1];
			foreach (var r in runs
				.SkipWhile(r => !r.ContainsCharType(FieldCharValues.Separate))
				.Skip(1)
				.TakeWhile(r=>r!= rEnd))
			{
				r.Remove();
			}
			rEnd.InsertBeforeSelf(CreateSimpleTextRun(replacementText));
		}
	}
	private static IList<Run> GetAssociatedRuns(FieldCode fieldCode)
	{
		Run rFieldCode = (Run)fieldCode.Parent;
		Run rBegin = rFieldCode.PreviousSibling<Run>();
		Run rCurrent = rFieldCode.NextSibling<Run>();
		var runs = new List<Run>(new[] { rBegin, rCurrent });
		while (!rCurrent.ContainsCharType(FieldCharValues.End))
		{
			rCurrent = rCurrent.NextSibling<Run>();
			runs.Add(rCurrent);
		};
		return runs;
	}
	private static bool ContainsCharType(this Run run, FieldCharValues fieldCharType)
	{
		var fc = run.GetFirstChild<FieldChar>();
		return fc == null
			? false
			: fc.FieldCharType.Value == fieldCharType;
	}
