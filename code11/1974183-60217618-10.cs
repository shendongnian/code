    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using PX.Data;
    namespace PX.SmsProvider.Plivo
    {
        public class PlivoSmsProvider : ISmsProvider
        {
            #region DetailIDs const
            private const string AuthID_DetailID = "AUTH_ID";
            private const string AuthToken_DetailID = "AUTH_TOKEN";
            private const string FromPhoneNbr_DetailID = "FROM_PHONE_NBR";
            #endregion
            #region DetailID_Display const
            private const string AuthID_DetailID_Display = "Auth ID";
            private const string AuthToken_DetailID_Display = "Auth Token";
            private const string FromPhoneNbr_DetailID_Display = "From Number";
            #endregion
            private string m_AuthID;
            public string AuthID { get { return m_AuthID; } }
            private string m_AuthToken;
            public string AuthToken { get { return m_AuthToken; } }
            private string m_FromPhoneNbr;
            public string FromPhoneNbr { get { return m_FromPhoneNbr; } }
            public IEnumerable<PXFieldState> ExportSettings
            {
                get
                {
                    var settings = new List<PXFieldState>();
                    var authID = (PXStringState)PXStringState.CreateInstance(
                        m_AuthID,
                        null,
                        false,
                        AuthID_DetailID,
                        null,
                        1,
                        null,
                        null,
                        null,
                        null,
                        null
                    );
                    authID.DisplayName = AuthID_DetailID_Display;
                    settings.Add(authID);
                    var authToken = (PXStringState)PXStringState.CreateInstance(
                        m_AuthToken,
                        null,
                        false,
                        AuthToken_DetailID,
                        null,
                        1,
                        "*",
                        null,
                        null,
                        null,
                        null
                    );
                    authToken.DisplayName = AuthToken_DetailID_Display;
                    settings.Add(authToken);
                    var fromPhoneNbr = (PXStringState)PXStringState.CreateInstance(
                        m_FromPhoneNbr,
                        null,
                        false,
                        FromPhoneNbr_DetailID,
                        null,
                        1,
                        null,
                        null,
                        null,
                        null,
                        null
                    );
                    fromPhoneNbr.DisplayName = FromPhoneNbr_DetailID_Display;
                    settings.Add(fromPhoneNbr);
                    return settings;
                }
            }
            public void LoadSettings(IEnumerable<ISmsProviderSetting> settings)
            {
                foreach (ISmsProviderSetting detail in settings)
                {
                    switch (detail.Name.ToUpper())
                    {
                        case AuthID_DetailID: m_AuthID = detail.Value; break;
                        case AuthToken_DetailID: m_AuthToken = detail.Value; break;
                        case FromPhoneNbr_DetailID: m_FromPhoneNbr = detail.Value; break;
                    }
                }
            }
            public async Task SendMessageAsync(SendMessageRequest request, CancellationToken cancellation)
            {
                // implement logic to send SMS
            }
        }
    }
