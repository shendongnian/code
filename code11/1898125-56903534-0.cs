    private void Button_Clicked(object sender, System.EventArgs e)
        {
            var _Script = string.Format("alert('test')");
            MessagingCenter.Send<object,string>(this,"Hi", _Script);
        }
