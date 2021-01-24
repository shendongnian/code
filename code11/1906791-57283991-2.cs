using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CamTest
{
    class Camera
    {
        public void CboOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///Declaration
            int num = cboOut.SelectedIndex;
            cmd = 0x101E;
            len = 0x0001;
            ///Code
            if (num == 0)
            {
                val = 0x03;
            }
            else if (num == 1)
            {
                val = 0x02;
            }
            else if (num == 2)
            {
                val = 0x01;
            }
            else
            {
                val = 0x00;
            }
            ///Pack
            Packs(len, cmd, val);
        }
        public void CboPol_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///Declaration
            int num = cboPol.SelectedIndex;
            len = 0x0000;
            ///Code
            if (num == 0)
            {
                cmd = 0x1030;
            }
            else
            {
                cmd = 0x1031;
            }
            ///Pack
            Packs(len, cmd, val);
        }
        public void CboAmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///Declaration
            int num = cboAmp.SelectedIndex;
            len = 0x0000;
            ///Code
            if (num == 0)
            {
                cmd = 0x102A;
            }
            else if (num == 1)
            {
                cmd = 0x102B;
            }
            else if (num == 2)
            {
                cmd = 0x102C;
            }
            else
            {
                cmd = 0x102D;
            }
            ///Pack
            Packs(len, cmd, val);
        }
        public void CboPro_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///Declaration
            int num = cboPro.SelectedIndex;
            len = 0x0000;
            ///Code
            if (num == 0)
            {
                cmd = 0x1017;
            }
            else
            {
                cmd = 0x1016;
            }
            ///Pack
            Packs(len, cmd, val);
        }
        public void CboFlip_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///Declaration
            int num = cboFlip.SelectedIndex;
            len = 0x0000;
            ///Code
            if (num == 0)
            {
                cmd = 0x1050;
            }
            else if (num == 1)
            {
                cmd = 0x1051;
            }
            else if (num == 2)
            {
                cmd = 0x1052;
            }
            else
            {
                cmd = 0x1053;
            }
            ///Pack
            Packs(len, cmd, val);
        }
        public void chkboxDDE_CheckedChanged(object sender, EventArgs e)
        {
            ///Declaration
            byte lit_val, lar_val;
            cmd = 0x1019;
            len = 0x0001;
            ///Code
            if (chkboxDDE.Checked)
            {
                lit_val = (byte)trkbarFine.Value;
                lar_val = (byte)trkbarCoarse.Value;
                val = (byte)((lar_val << 4) + lit_val);
            }
            else
            {
                cmd = 0x1018;
                len = 0x0000;
            }
            ///Pack
            Packs(len, cmd, val);
        }
        public void TrkbarFine_Scroll(object sender, EventArgs e)
        {
            ///Declaration
            byte lit_val, lar_val;
            cmd = 0x1019;
            len = 0x0001;
            ///Code
            if (chkboxDDE.Checked)
            {
                lit_val = (byte)trkbarFine.Value;
                lar_val = (byte)trkbarCoarse.Value;
                val = (byte)((lar_val << 4) + lit_val);
            }
            else
            {
                return;
            }
            ///Pack
            Packs(len, cmd, val);
        }
        public void TrkbarCoarse_Scroll(object sender, EventArgs e)
        {
            ///Declaration
            byte lit_val, lar_val;
            cmd = 0x1019;
            len = 0x0001;
            ///Code
            if (chkboxDDE.Checked)
            {
                lit_val = (byte)trkbarFine.Value;
                lar_val = (byte)trkbarCoarse.Value;
                val = (byte)((lar_val << 4) + lit_val);
            }
            else
            {
                return;
            }
            ///Pack
            Packs(len, cmd, val);
        }
        public void chkboxMan_CheckedChanged(object sender, EventArgs e)
        {
            ///Declaration
            uint gain, offset;
            cmd = 0x1020;
            len = 0x0004;
            if (chkboxMan.Checked)
            {
                gain = (uint)trkbarCon.Value;
                offset = (uint)trkbarBright.Value;
                val = (gain << 16) + offset;
            }
            else
            {
                cmd = 0x1021;
                len = 0x0000;
            }
            ///Pack
            Packs(len, cmd, val);
        }
        public void TrkbarCon_Scroll(object sender, EventArgs e)
        {
            ///Declaration
            uint gain, offset;
            cmd = 0x1020;
            len = 0x0004;
            ///Code
            if (chkboxMan.Checked)
            {
                gain = (uint)trkbarCon.Value;
                offset = (uint)trkbarBright.Value;
                val = (gain << 16) + offset;
            }
            else
            {
                return;
            }
            ///Pack
            Packs(len, cmd, val);
        }
        public void TrkbarBright_Scroll(object sender, EventArgs e)
        {
            ///Declaration
            uint gain, offset;
            len = 0x0004;
            cmd = 0x1020;
            ///Code
            if (chkboxMan.Checked)
            {
                gain = (uint)trkbarCon.Value;
                offset = (uint)trkbarBright.Value;
                val = (gain << 16) + offset;
            }
            else
            {
                return;
            }
            ///Pack
            Packs(len, cmd, val);
        }
        public void chkboxCursor_CheckedChanged(object sender, EventArgs e)
        {
            ///Declaration
            len = 0x0001;
            cmd = 0x1034;
            ///Code
            if (chkboxCursor.Checked)
            {
                val = 0x01;
            }
            else
            {
                val = 0x00;
            }
            ///Pack
            Packs(len, cmd, val);
        }
        public void SendPosition(int Ypos, int Xpos)
        {
            ///Declaration
            cmd = 0x1035;
            len = 0x0004;
            ///Code
            val = (uint)((Ypos << 16) + Xpos);
            ///Pack
            Packs(len, cmd, val);
        }
        public void btnTt_Click(object sender, EventArgs e)
        {
            int y;
            y = int.Parse(txtboxY.Text);
            if ((y - 16) < 0)
            {
                return;
            }
            else
            {
                y -= 16;
                txtboxY.Text = y.ToString();
            }
            int x = int.Parse(txtboxX.Text);
            SendPosition(y, x);
        }
        public void BtnT_Click(object sender, EventArgs e)
        {
            int y;
            y = int.Parse(txtboxY.Text);
            if (y <= 0)
            {
                return;
            }
            else
            {
                y--;
                txtboxY.Text = y.ToString();
            }
            int x = int.Parse(txtboxX.Text);
            SendPosition(y, x);
        }
        public void BtnD_Click(object sender, EventArgs e)
        {
            int y;
            y = int.Parse(txtboxY.Text);
            if (y >= (height - 1))
            {
                return;
            }
            else
            {
                y++;
                txtboxY.Text = y.ToString();
            }
            int x = int.Parse(txtboxX.Text);
            SendPosition(y, x);
        }
        public void BtnDd_Click(object sender, EventArgs e)
        {
            int y;
            y = int.Parse(txtboxY.Text);
            if ((y + 16) > (height - 1))
            {
                return;
            }
            else
            {
                y += 16;
                txtboxY.Text = y.ToString();
            }
            int x = int.Parse(txtboxX.Text);
            SendPosition(y, x);
        }
        public void BtnL_Click(object sender, EventArgs e)
        {
            int x;
            x = int.Parse(txtboxX.Text);
            if (x <= 0)
            {
                return;
            }
            else
            {
                x--;
                txtboxX.Text = x.ToString();
            }
            int y = int.Parse(txtboxY.Text);
            SendPosition(y, x);
        }
        public void BtnLl_Click(object sender, EventArgs e)
        {
            int x;
            x = int.Parse(txtboxX.Text);
            if ((x - 16) < 0)
            {
                return;
            }
            else
            {
                x -= 16;
                txtboxX.Text = x.ToString();
            }
            int y = int.Parse(txtboxY.Text);
            SendPosition(y, x);
        }
        public void BtnR_Click(object sender, EventArgs e)
        {
            int x;
            x = int.Parse(txtboxX.Text);
            if (x >= (width - 1))
            {
                return;
            }
            else
            {
                x++;
                txtboxX.Text = x.ToString();
            }
            int y = int.Parse(txtboxY.Text);
            SendPosition(y, x);
        }
        public void BtnRr_Click(object sender, EventArgs e)
        {
            int x;
            x = int.Parse(txtboxX.Text);
            if ((x + 16) > (width - 1))
            {
                return;
            }
            else
            {
                x += 16;
                txtboxX.Text = x.ToString();
            }
            int y = int.Parse(txtboxY.Text);
            SendPosition(y, x);
        }
        public void BtnMid_Click(object sender, EventArgs e)
        {
            txtboxX.Text = (width / 2).ToString();
            txtboxY.Text = (height / 2).ToString();
            int x = int.Parse(txtboxX.Text);
            int y = int.Parse(txtboxY.Text);
            SendPosition(y, x);
        }
    }
}
Only specify `private` if you only plan to call that function from within the same class. Do note, however, that no accessibility modifier means that it's private.
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers
