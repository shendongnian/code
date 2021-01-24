public override void OnBackPressed () {
    var masterDetailPage = Application.Current.MainPage as MasterDetailPage;
    if (Application.Current.MainPage as MasterDetailPage masterdDetailPage) {
        //need to pop from detail page of MasterDetailPage
        if (masterDetailPage.Detail.Navigation.Count>0)
            masterDetailPage.Detail.PopAsync (true);
    } else {
        base.OnBackPressed ();
    }
}
