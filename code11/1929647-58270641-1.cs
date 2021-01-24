        public void Notification(string title, string message)
        {
            PopupTitle.Text = title;
            PopupMessage.Text = message;
            OkBtn.Text = "OK";
            CancelBtn.Visible = false;
            Notification.Show();
        }
