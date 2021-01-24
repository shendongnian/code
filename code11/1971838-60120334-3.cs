    public void Handle_OnScanResult(Result result)
    {
       string wynik = result.Text;
       Parent.Receive_result(wynik);
       Application.Current.MainPage.Navigation.PopModalAsync();
    }
