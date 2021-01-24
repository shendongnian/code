    public async void LoadItems()
        {
            isLoading = true;
            Show();
            listView.ItemsSource = null;
            bas = bas + 100;
            bit = bit + 100;
            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
              Mobil.webService.KartServis service = new Mobil.webService.KartServis()
              {
                 Url = Application.Current.Properties["servisyolu"].ToString()
              };
              List<Mobil.webService.Musteriler> MusteriLists = new List<Mobil.webService.Musteriler>(service.MusteriListele("K", bas, bit, mKodu, mFirma, mSehir, mSemt, mIlce, mAdres, Application.Current.Properties["lisans"].ToString(), Application.Current.Properties["KNO"].ToString()));
              foreach (Mobil.webService.Musteriler items in MusteriLists)
              {
                  Items.Add(new Musteriler { Kodu = items.Kodu, Firma = items.Firma,   Adres = items.Adres, Telefon = items.Telefon, Sayi = items.Sayi });
              }
              for (int i = 0; i < Items.Count; i++)
              {
                Console.WriteLine(Items[i].Sayi);
              }
              var lastItem = Items[1];
              listView.ItemsSource = Items;
              isLoading = false;
              listView.SelectedItem = lastItem;
              listView.ScrollTo(listView.SelectedItem, ScrollToPosition.MakeVisible, false);
              Hide();
            });
        }
