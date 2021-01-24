		private ICommand _PreviewMouseWheelCommand;
		public ICommand PreviewMouseWheelCommand => this._PreviewMouseWheelCommand ?? (this._PreviewMouseWheelCommand = new RelayCommand(OnPreviewMouseWheel));
		private void OnPreviewMouseWheel()
		{
			this.IsDropDown = false;
		}
