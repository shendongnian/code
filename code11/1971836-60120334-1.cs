    public void Handle_OnScanResult(Result result)
    {
       string wynik = result.Text;
       parent.Receive_result(wynik);
       Application.Current.MainPage.Navigation.PopModalAsync();
    }
