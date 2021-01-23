    private void OnCalculateCompleted(InvokeOperation response)
    {
      if (response.HasError == false)
      {
        // Do stuff with result
      }
      else
      {
        MessageBox.Show(response.Error.Message);
        response.MarkErrorAsHandled();
      }
    }
