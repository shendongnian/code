    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data;
    using System.Data.Sql;
    using System.Data.SqlClient;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            string x = Request.QueryString["SubmissionId"];
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            string editCustQuery = "SELECT CustName, SicNaic, CustCity, CustAdd, CustState, CustZip FROM Customer WHERE SubId =" + x;
            string editBroQuery = "SELECT BroName, BroAdd, BroCity, BroState, BroZip, EntityType FROM Broker WHERE SubId =" + x; 
            string editSubQuery = "SELECT Coverage, CurrentCoverage, PrimEx, Retention, EffectiveDate, Commission, Premium, Comments FROM Submission WHERE SubmissionId =" + x;
            string epl = "SELECT Entity, Employees, CA, MI, NY, NJ, Primex, EplLim, EplSir, Premium, Wage, Sublim FROM EPL WHERE SubmissionId =" + x;
            string prof = "SELECT Primex, EO, Limit, Retention, Att, Prem, Sublim, Entity FROM ProfessionalEO WHERE SubmissionId =" + x;
            string crim = "SELECT Entity, Employees, PrimEx, LimA, DedA, PremA, LimitB, DedB, PremB FROM CrimeFidelity WHERE SubmissionId =" + x;
            string fid = "SELECT Entity, PrimEx, Limit, SIR, Att, Premium, Sublim FROM Fiduciary WHERE SubmissionId =" + x;
            string not = "SELECT PrimEx, Coverage, SharedSepLim, TradLim, TradDoSir, EplLim, EplSir, EplPrem, EplSublim FROM NotProfit WHERE SubmissionId =" + x;
            string priv = "SELECT Primex, SharedSepLim, TradLim, TradAtt, TradDoSir, TradPrem, EplLim, EplSir, EplAtt, EplWage, EplPrem, EplInvest, FidLim, FidSir, FidAtt, FidPrem, FidSublim FROM PrivateCompany WHERE SubmissionId =" + x;
            string pub = "SELECT Market, Ticker, TradABC, DIC, Limit, SecuritiesSir, OtherSir, Premium, PrimEx, Att, Sublim FROM PublicDO WHERE SubmissionId =" + x;
            using (SqlConnection editConn = new SqlConnection(connectionString))
            {
                editConn.Open();
    
                using (SqlCommand CustCommand = new SqlCommand(editCustQuery, editConn))
                {
    
                    SqlDataReader dr = CustCommand.ExecuteReader();
                    dr.Read();
                    LblCustName.Text = dr.GetString(0);
                    LblSicNaic.Text = dr.GetString(1);
                    LblCustCity.Text = dr.GetString(2);
                    LblCustAddress.Text = dr.GetString(3);
                    LblCustState.Text = dr.GetString(4);
                    LblCustZip.Text = dr.GetInt32(5).ToString();
                    dr.Close();
                }
                using (SqlCommand BroCommand = new SqlCommand(editBroQuery, editConn))
                {
                    SqlDataReader dr = BroCommand.ExecuteReader();
                    dr.Read();
                    LblBroName.Text = dr.GetString(0);
                    LblBroAddress.Text = dr.GetString(1);
                    LblBroCity.Text = dr.GetString(2);
                    LblBroState.Text = dr.GetString(3);
                    LblBroZip.Text = dr.GetInt32(4).ToString();
                    LblEntity.Text = dr.GetString(5);
                    dr.Close();
                }
                using (SqlCommand SubCommand = new SqlCommand(editSubQuery, editConn))
                {
                    SqlDataReader dr = SubCommand.ExecuteReader();
                    dr.Read();
                    LblCoverage.Text = dr.GetInt32(0).ToString();
                    LblCurrentCoverage.Text = dr.GetInt32(1).ToString();
                    LblPrimEx.Text = dr.GetInt32(2).ToString();
                    LblRetention.Text = dr.GetInt32(3).ToString();
                    LblEffectDate.Text = dr.GetDateTime(4).ToString();
                    LblCommission.Text = dr.GetInt32(5).ToString();
                    LblPremium.Text = dr.GetInt32(6).ToString();
                    LblComments.Text = dr.GetString(7);
                    dr.Close();
                    HyperLink1.NavigateUrl = "~/ViewEdit.aspx?SubmissionId=" + x;
                }
                    string viewQuery = "SELECT ProductId FROM SubmissionProducts WHERE SubmissionId =" + x;
    
                    SqlCommand viewcmd = new SqlCommand(viewQuery, editConn);
    
                    SqlDataReader drRows = viewcmd.ExecuteReader();
                    while (drRows.Read())
                        {
                            switch (drRows.GetInt32(0))
                            {
                                case 1:
                                    PanelEplShow.Visible = true;
                                    using (SqlCommand eplviewcmd = new SqlCommand(epl, editConn))
                                    {
                                        SqlDataReader epldr = eplviewcmd.ExecuteReader();
                                        epldr.Read();
                                        LblEplShowEntity.Text = epldr.GetString(0);
                                        LblEplShowTotalEmpl.Text = epldr.GetInt32(1).ToString();
                                        LblEplShowCalEmpl.Text = epldr.GetInt32(2).ToString();
                                        LblEplShowMichEmpl.Text = epldr.GetInt32(3).ToString();
                                        LblEplShowNyEmpl.Text = epldr.GetInt32(4).ToString();
                                        LblEplShowNjEmpl.Text = epldr.GetInt32(5).ToString();
                                        LblEplShowPrimEx.Text = epldr.GetInt32(6).ToString();
                                        LblEplShowLim.Text = epldr.GetInt32(7).ToString();
                                        LblEplShowSir.Text = epldr.GetInt32(8).ToString();
                                        LblEplShowPrem.Text = epldr.GetInt32(9).ToString();
                                        LblEplShowWage.Text = epldr.GetInt32(10).ToString();
                                        LblEplShowInvestCost.Text = epldr.GetInt32(11).ToString();
                                        epldr.Close();
                                    }
                                    break;
                                case 2:
                                    PanelProfShow.Visible = true;
                                    using (SqlCommand profcmd = new SqlCommand(prof, editConn))
                                    {
                                        SqlDataReader profdr = profcmd.ExecuteReader();
                                        profdr.Read();
                                        LblProfShowPrimEx.Text = profdr.GetInt32(0).ToString();
                                        LblProfShowType.Text = profdr.GetString(1);
                                        LblProfShowLim.Text = profdr.GetInt32(2).ToString();
                                        LblProfShowRetention.Text = profdr.GetInt32(3).ToString();
                                        LblProfShowAtt.Text = profdr.GetInt32(4).ToString();
                                        LblProfShowPrem.Text = profdr.GetInt32(5).ToString();
                                        LblProfShowSublim.Text = profdr.GetInt32(6).ToString();
                                        LblProfShowEntity.Text = profdr.GetString(7);
                                        profdr.Close();
                                    }
                                    break;
                                case 3:
                                    PanelCrimeShow.Visible = true;
                                    using (SqlCommand crimcmd = new SqlCommand(crim, editConn))
                                    {
                                        SqlDataReader crimdr = crimcmd.ExecuteReader();
                                        crimdr.Read();
                                        LblCrimeShowEntity.Text = crimdr.GetString(0);
                                        LblCrimeShowEmpl.Text = crimdr.GetInt32(1).ToString();
                                        LblCrimeShowPrimEx.Text = crimdr.GetInt32(2).ToString();
                                        LblCrimeShowLimA.Text = crimdr.GetInt32(3).ToString();
                                        LblCrimeShowDedA.Text = crimdr.GetInt32(4).ToString();
                                        LblCrimeShowPremA.Text = crimdr.GetInt32(5).ToString();
                                        LblCrimeShowLimB.Text = crimdr.GetInt32(6).ToString();
                                        LblCrimeShowDedB.Text = crimdr.GetInt32(7).ToString();
                                        LblCrimeShowPremB.Text = crimdr.GetInt32(8).ToString();
                                        crimdr.Close();
                                    }
                                    break;
                                case 4:
                                    PanelFidShow.Visible = true;
                                    using (SqlCommand fidcmd = new SqlCommand(fid, editConn))
                                    {
                                        SqlDataReader fiddr = fidcmd.ExecuteReader();
                                        fiddr.Read();
                                        LblFidShowEntity.Text = fiddr.GetString(0);
                                        LblFidShowPrimEx.Text = fiddr.GetInt32(1).ToString();
                                        LblFidShowLim.Text = fiddr.GetInt32(2).ToString();
                                        LblFidShowSir.Text = fiddr.GetInt32(3).ToString();
                                        LblFidShowAtt.Text = fiddr.GetInt32(4).ToString();
                                        LblFidShowPrem.Text = fiddr.GetInt32(5).ToString();
                                        LblFidShowSublim.Text = fiddr.GetInt32(6).ToString();
                                        fiddr.Close();
                                    }
                                    break;
                                case 5:
                                    PanelNotShow.Visible = true;
                                    using (SqlCommand notcmd = new SqlCommand(not, editConn))
                                    {
                                        SqlDataReader notdr = notcmd.ExecuteReader();
                                        notdr.Read();
                                        LblNotShowPrimEx.Text = notdr.GetInt32(0).ToString();
                                        LblNotShowCov.Text = notdr.GetInt32(1).ToString();
                                        LblNotShowSharedLim.Text = notdr.GetInt32(2).ToString();
                                        LblNotShowTradLim.Text = notdr.GetInt32(3).ToString();
                                        LblNotShowTradSir.Text = notdr.GetInt32(4).ToString();
                                        LblNotShowEplLim.Text = notdr.GetInt32(5).ToString();
                                        LblNotShowEplSir.Text = notdr.GetInt32(6).ToString();
                                        LblNotShowEplPrem.Text = notdr.GetInt32(7).ToString();
                                        LblNotShowSublim.Text = notdr.GetInt32(8).ToString();
                                        notdr.Close();
                                    }
                                    break;
                                case 6:
                                    PanelPrivShow.Visible = true;
                                    using (SqlCommand privcmd = new SqlCommand(priv, editConn))
                                    {
                                        SqlDataReader privdr = privcmd.ExecuteReader();
                                        privdr.Read();
                                        LblPrivShowPrimEx.Text = privdr.GetInt32(0).ToString();
                                        LblPrivShowSharedLim.Text = privdr.GetInt32(1).ToString();
                                        LblPrivShowTradLim.Text = privdr.GetInt32(2).ToString();
                                        LblPrivShowTradAtt.Text = privdr.GetInt32(3).ToString();
                                        LblPrivShowTradSir.Text = privdr.GetInt32(4).ToString();
                                        LblPrivShowTradPrem.Text = privdr.GetInt32(5).ToString();
                                        LblPrivShowEplLim.Text = privdr.GetInt32(6).ToString();
                                        LblPrivShowEplSir.Text = privdr.GetInt32(7).ToString();
                                        LblPrivShowEplAtt.Text = privdr.GetInt32(8).ToString();
                                        LblPrivShowEplPrem.Text = privdr.GetInt32(9).ToString();
                                        LblPrivShowEplWage.Text = privdr.GetInt32(10).ToString();
                                        LblPrivShowEplSublim.Text = privdr.GetInt32(11).ToString();
                                        LblPrivShowFidLim.Text = privdr.GetInt32(12).ToString();
                                        LblPrivShowFidSir.Text = privdr.GetInt32(13).ToString();
                                        LblPrivShowFidAtt.Text = privdr.GetInt32(14).ToString();
                                        LblPrivShowFidPrem.Text = privdr.GetInt32(15).ToString();
                                        LblPrivShowFidSublim.Text = privdr.GetInt32(16).ToString();
                                        privdr.Close();
                                    }
                                    break;
                                case 7:
                                    PanelPubShow.Visible = true;
                                    using (SqlCommand pubcmd = new SqlCommand(pub, editConn))
                                    {
                                        SqlDataReader pubdr = pubcmd.ExecuteReader();
                                        pubdr.Read();
                                        LblPubShowMark.Text = pubdr.GetInt32(0).ToString();
                                        LblPubShowTick.Text = pubdr.GetInt32(1).ToString();
                                        LblPubShowTrad.Text = pubdr.GetInt32(2).ToString();
                                        LblPubShowDic.Text = pubdr.GetString(3);
                                        LblPubShowLim.Text = pubdr.GetInt32(4).ToString();
                                        LblPubShowSecSir.Text = pubdr.GetInt32(5).ToString();
                                        LblPubShowAllSir.Text = pubdr.GetInt32(6).ToString();
                                        LblPubShowPrem.Text = pubdr.GetInt32(7).ToString();
                                        LblPubShowPrimEx.Text = pubdr.GetInt32(8).ToString();
                                        LblPubShowAtt.Text = pubdr.GetInt32(9).ToString();
                                        LblPubShowSublim.Text = pubdr.GetInt32(10).ToString();
                                        pubdr.Close();
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    drRows.Close();
                                                   
            }        
        }   
    }
