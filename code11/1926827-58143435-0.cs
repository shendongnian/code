    public string ReadForm(FormViewModel formModel)
    {
    	string formText = formModel.FormText;
    	formText = formText.Replace("[[placeholder1]]", GetItems1(formModel.ID));
    	formText = formText.Replace("[[placeholder2]]", GetItems2(formModel.ID));
    	formText = formText.Replace("[[placeholder3]]", GetItems3(formModel.ID));
    	formText = formText.Replace("[[placeholder4]]", GetItems4(formModel.ID));
    	formText = Regex.Replace(formText, @"\[\[(.*?)\]\]", "$1");
    	return formText;
    }
