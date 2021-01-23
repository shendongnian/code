     for (int i = 0; i < lstKullanicilar.Items.Count; i++) {
       while(lstKullanicilar.Items[i].Count > 1){
          lstKullanicilar.Items[i].SubItems.RemoveAt(1);
       }
     }
