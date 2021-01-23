    public void ProcessFiles()
    {
      var resultText = new StringBuilder();
    
      if (PandaCheckBox.Checked)
      {
        var result = DoPandaProcessing(); // Read file and do whatever here
        resultText.Append(result.ResultMessage);
      }
    
      if (Process2CheckBox.Checked)
      {
        var result = DoProcess2Processing();
        if (resultText.Length > 0)
        {
          resultText.Append(Environment.NewLine);
        }
        resultText.Append(result.ResultMessage);
      }
    
      MessageBox.Show(resultText.ToString());
    }
