      --------------------aspx page code----------------------
      <asp:Panel ID="pnlForgot" runat="server" DefaultButton="btnGet">
                    <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1"
                        id="myModal" class="modal fade">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                        &times;</button>
                                    <h4 class="modal-title">
                                        Forgot Password ?</h4>
                                </div>
                                <div class="modal-body">
                                    <asp:Label ID="lblMsg1" runat="server" Style="color: red; font-weight: 400;"></asp:Label>&nbsp;
                                    <p>
                                        Enter your E-Mail ID below to reset your password.</p>
                                    <asp:Label ID="passlabel" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtMailorMobile" runat="server" MaxLength="100" placeholder="E-Mail ID"
                                        autocomplete="off" class="form-control placeholder-no-fix" Style="margin-bottom: 0" autofocus required></asp:TextBox>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" data-dismiss="modal" class="btn btn-default" />
                                    <asp:Button ID="btnGet" runat="server" OnClick="btnForgot_Click" Text="Get Password"
                                        class="btn btn-primary" OnClientClick="return validate();" />
                                    <asp:HiddenField ID="hfPassword" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
    			
    			----------------------aspx.cs code----------------------
    			 protected void btnForgot_Click(object sender, EventArgs e)
        {
            try
            {
                //String pass = "select AppMstPassword from AppMst where AppMstEMailId like'" + txtMailorMobile.Text + "'";
                string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                SqlConnection con = new SqlConnection(str);
                DataWrapper objdatawrapper = new DataWrapper(str, CommandType.StoredProcedure);
                objdatawrapper.AddParameter("@email", txtMailorMobile.Text, SqlDbType.VarChar);
                SqlParameter sp = (SqlParameter)objdatawrapper.AddParameter("@password", null, SqlDbType.VarChar, ParameterDirection.Output, 200);
                DataSet ds = new DataSet();
                ds = objdatawrapper.ExecuteDataSet("forgetpassword");
                if (sp.Value.ToString() !="" || sp.Value.ToString()==null)
                {
                    passlabel.Text = sp.Value.ToString();
                    passlabel.Visible = false;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password has been sent to your mail id')", true);
    
                }
                else
                {
                    passlabel.Text = "You are not a registered member";
                    passlabel.Visible = false;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You are not a registered member')", true);
                }
                
            }
            catch(Exception ex)
            {
                string mg = ex.ToString();
            }
    
    
    
            string MailMsg = "";
            
    
    
    
    
            MailMsg += "<table style='background:white;width:544px;font-size: 14.0px;border: 2.0px solid #e8e8e8;margin-left: 180px;'>";
            MailMsg += "<tr>";
            MailMsg += "<td style='background-color:#ffffff;' align='center'> </td>";
            MailMsg += "</tr>";
    
            MailMsg += "<tr align='center' style='background: #1b88ce;padding: 10px 5px;'>";
            MailMsg += "<td><h2 align='center' style='text-align: center;color: #ffffff;font-size:22px;font-weight:normal;margin:0;'>Reset Password </h2></td>";
            MailMsg += "</tr>";
    
            MailMsg += "<tr>";
            MailMsg += "<td><br/></td>";
            MailMsg += "</tr>";
    
            MailMsg += "<tr>";
            MailMsg += "<td>Hi Sir/Mam, </td>";
            MailMsg += "</tr>";
    
            MailMsg += "<tr>";
            MailMsg += "<td><br/></td>";
            MailMsg += "</tr>";
    
            MailMsg += "<tr>";
            MailMsg += "<td>You recently requested a password reset.your password is '"+passlabel.Text+"'</td>";
    //        MailMsg += passlabel.Text;
            MailMsg += "</tr>";
    
            MailMsg += "<tr>";
            MailMsg += "<td><br/></td>";
            MailMsg += "</tr>";
    
            MailMsg += "<tr>";
            MailMsg += "<td>The link will expire in 24 Hours.If you did not make this request, you may simply ignore this email. </td>";
            MailMsg += "</tr>";
    
            MailMsg += "<tr>";
            MailMsg += "<td><br/></td>";
            MailMsg += "</tr>";
    
            MailMsg += "<tr>";
            MailMsg += "<td>Thank You,<br/> Our Company Name</td>";
            MailMsg += "</tr>";
    
            MailMsg += "<tr>";
            MailMsg += "<td><br/></td>";
            MailMsg += "</tr>";
    
            MailMsg += "<tr>";
            MailMsg += "<td style='border-bottom:1px solid #DDDDDD;'></td>";
            MailMsg += "</tr>";
    
            MailMsg += "<tr>";
            MailMsg += "<td><br/></td>";
            MailMsg += "</tr>";
    
            MailMsg += "<tr>";
            MailMsg += "<td><p> Any Message type here</p></td>";
            MailMsg += "</tr>";
    
    
    
            MailMsg += "<tr>";
            MailMsg += "<td><br/><br/></td>";
            MailMsg += "</tr>";
    
            MailMsg += "</table>";
           MailMsg = MailMsg + "<p style='padding:10px; line-height:8px; font-size:12px; font-family:Verdana, Geneva, sans-serif;'>Proud Leagal Team </p></div>";
            Mail.SendMailMessage("xyz@gmail.com", "" + txtMailorMobile.Text + "", "!!! XYZ !!! Forgot Password", "" + MailMsg.ToString() + "");
    
            reset();
        }
    	
    	
    	-----------------Add this App Code File---------------
    	
    	using System;
    using System.Data;
    using System.Configuration;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Xml.Linq;
    using System.Net;
    using System.IO;
    namespace businesslayer
    {
        public class SMS
        {
            public SMS()
            {
                // TODO: Add constructor logic here
            }
            public static String sendsms(string No, string Msg)
            {
                String status="";
                try
                {
                    String req;
                    req = "http://sms.xyz.com/WebServiceSMS.aspx?User=xyzsms&passwd=1234&mobilenumber=" + No + "&message=" + Msg + "&sid=XYZ&mtype=N";
            
                    HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(req);
                    HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                    System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                    string responseString = respStreamReader.ReadToEnd();
                    respStreamReader.Close();
                    myResp.Close();
                    status = responseString;
                }
                catch (Exception ex)
                {
                    status = "URL is not responding at the moment." + ex.Message.ToString();
                }
                return status;
            }
        }
    }
