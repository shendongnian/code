     protected void Button1_Click(object sender, EventArgs e)
        {
            if (ddlPlayer1.SelectedIndex>0 || ddlPlayer2.SelectedIndex>0)
            {
                lblPlayer1Score.Text = Repository.Instance.ReturnScore(ddlPlayer1.SelectedValue.ToString(), ddlPlayer2.SelectedValue.ToString()).Rows[0][0].ToString();
                lblPlayer2Score.Text = Repository.Instance.ReturnScore(ddlPlayer2.SelectedValue.ToString(), ddlPlayer1.SelectedValue.ToString()).Rows[0][0].ToString();
            }
        }
