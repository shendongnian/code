    private void BtnEmisor_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send((App)Application.Current,"BtnEmisor_Clicked");
            PopupNavigation.Instance.PopAllAsync();
            VGlobales.sRFSeleccionado = sEmisor;
        }
