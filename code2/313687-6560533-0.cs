    using System;
    using System.Drawing;
    using System.Windows.Forms;
     
    public static class CustomMessageBox
    {
        public static DialogResult Show(string Text, string Title, eDialogButtons Buttons, Image Image)
        {
            MessageForm message = new MessageForm();
            message.Text = Title;
     
            if (Image.Height < 0 || Image.Height > 64)
                throw new Exception("Invalid image height. Valid height ranges from 0 to 64.");
            else if (Image.Width < 0 || Image.Width > 64)
                throw new Exception("Invalid image width. Valid width ranges from 0 to 64.");
            else
            {
                message.picImage.Image = Image;
                message.lblText.Text = Text;
     
                switch (Buttons)
                {
                    case eDialogButtons.OK:
                        message.btnYes.Visible = false;
                        message.btnNo.Visible = false;
                        message.btnCancel.Visible = false;
                        message.btnOK.Location = message.btnCancel.Location;
                        break;
                    case eDialogButtons.OKCancel:
                        message.btnYes.Visible = false;
                        message.btnNo.Visible = false;
                        break;
                    case eDialogButtons.YesNo:
                        message.btnOK.Visible = false;
                        message.btnCancel.Visible = false;
                        message.btnYes.Location = message.btnOK.Location;
                        message.btnNo.Location = message.btnCancel.Location;
                        break;
                    case eDialogButtons.YesNoCancel:
                        message.btnOK.Visible = false;
                        break;
                }
     
                if (message.lblText.Height > 64)
                    message.Height = (message.lblText.Top + message.lblText.Height) + 78;
     
                return (message.ShowDialog());
            }
        }
     
        public enum eDialogButtons { OK, OKCancel, YesNo, YesNoCancel }
    }
