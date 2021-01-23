    private void CreateDialogSeek()
		{
			
			dialogSeek = new Dialog(this);
			dialogSeek.SetContentView(Resource.Layout.seekbar_dialog);
			dialogSeek.SetTitle("Change your configuration"); 
			dialogSeek.SetCancelable(true);
			  //Ok
			  btnOk = (Button)(dialogSeek.FindViewById(Resource.Id.btnSettingsOKSeekBar));
			  btnCancel = (Button)(dialogSeek.FindViewById(Resource.Id.btnSettingsCancelSeekBar));
			  SeekBar mSeekBar = (SeekBar)(dialogSeek.FindViewById(Resource.Id.seekbar));
		      mSeekBar.Progress = cache;
			  mSeekBar.SetOnSeekBarChangeListener(this);
		    dialogSeek.Show();
	        btnOk.Click += delegate {OKSeek();};
			btnCancel.Click += delegate {dialogSeek.Dismiss();;};
		}
		
		public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
		{
			cache = progress;
        }
        public void OnStartTrackingTouch(SeekBar seekBar)
        {
        }
        public void OnStopTrackingTouch(SeekBar seekBar)
        {
        }
