     string caseType = null;
            if (!String.IsNullOrEmpty(viewModel.CaseTypeValue))
            {
                caseType = HttpUtility.UrlEncode(viewModel.CaseTypeValue, System.Text.Encoding.Default);
            }
