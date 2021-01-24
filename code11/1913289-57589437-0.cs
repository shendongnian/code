    using DevExpress.XtraEditors;
    using System;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using System.Data.Entity;
    
    namespace myHome
    {
        public partial class frmLogin : DevExpress.XtraEditors.XtraForm
        {
            public frmLogin()
            {
                InitializeComponent();
            }
    
            private void labelControl3_Click(object sender, EventArgs e)
            {
    
            }
    
            private void linkSite_Click(object sender, EventArgs e)
            {
                System.Diagnostics.Process.Start("http://www.pishdad.org");
            }
    
            private void btnInput_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(txtUser.Text))
                {
                    XtraMessageBox.Show("نام کاربری وارد نشده است", "پیام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUser.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(txtPass.Text))
                {
                    XtraMessageBox.Show("رمز کاربری وارد نشده است", "پیام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPass.Focus();
                    return;
                }
    
    
                try
    
                {
                    IQueryable query = null;
                    using (myHomeEntities db = new myHomeEntities())
                    {
                        query = from u in db.TB_User
                            where u.UserName == txtUser.Text && u.PassWord == txtPass.Text
                            select u;
    
                    }
    
    
                    if (query.ToList().SingleOrDefault() != null)
                    {
                        XtraMessageBox.Show("شما دسترسی پیدا کردید! ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("ورود نا  معتبر! ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
    
            private void BtnExit_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
    }
