		protected string ProcessReplacements(Guid versionId, Guid surveyId, string input)
		{
			if (input == null)
				return null;
			List<ObjectParameter> parameters = new List<ObjectParameter>(3);
			parameters.Add(new ObjectParameter("VersionId", versionId));
			parameters.Add(new ObjectParameter("SurveyId", surveyId));
			parameters.Add(new ObjectParameter("Input", input));
			var output = db.CreateQuery<string>("SurveyDesignerModel.Store.ProcessReplacements(@VersionId, @SurveyId, @Input)", parameters.ToArray())
				.Execute(MergeOption.NoTracking)
				.FirstOrDefault();
			return output;
		}
