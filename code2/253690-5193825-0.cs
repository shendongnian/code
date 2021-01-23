    public class MailMessage
    {
        #region Constants and Fields
        private readonly string _body;
        private readonly string _subject;
        private readonly List<MapiFileDesc> _attachments;
        private readonly List<MapiRecipDesc> _recipients;
        #endregion
        #region Constructors and Destructors
        private MailMessage()
        {
        }
        public MailMessage(
            string subject, string body, IEnumerable<MailAttachment> attachments, IEnumerable<MailRecipient> recipients)
        {
            this._subject = subject;
            this._body = body;
            this._attachments = new List<MapiFileDesc>();
            this._recipients = new List<MapiRecipDesc>();
            if (attachments != null)
            {
                foreach (var attachment in attachments)
                {
                    _attachments.Add(attachment.GetMapiFileDesc());
                }
            }
            if (recipients != null)
            {
                foreach (var recipient in recipients)
                {
                    _recipients.Add(recipient.GetMapiRecipDesc());
                }
            }
        }
        #endregion
        #region Public Methods
        public void ShowDialog()
        {
            int result = this.ShowMail();
            if (!IsSuccess(result))
            {
                throw new Exception(GetMapiErrorMessage(result));
            }
        }
        #endregion
        #region Methods
        private int ShowMail()
        {
            var message = new MapiMessage();
            message.Subject = this._subject;
            message.NoteText = this._body;
            int attachmentCount;
            message.Files = AllocMapiDescArray(_attachments, out attachmentCount);
            message.FileCount = attachmentCount;
            int recipientCount;
            message.Recipients = AllocMapiDescArray(_recipients, out recipientCount);
            message.RecipientCount = recipientCount;
            int error = Mapi32.MAPISendMail(IntPtr.Zero, IntPtr.Zero, message, Mapi32.MAPI_DIALOG, 0);
            DeallocMapiDescArray<MapiFileDesc>(message.Files, message.FileCount);
            DeallocMapiDescArray<MapiRecipDesc>(message.Recipients, message.RecipientCount);
            return error;
        }
        private static IntPtr AllocMapiDescArray<T>(ICollection<T> mapiDescCollection, out int mapiDescCount)
        {
            IntPtr mapiMapiDescArrayPtr = IntPtr.Zero;
            mapiDescCount = 0;
            if (mapiDescCollection != null && mapiDescCollection.Count > 0)
            {
                int mapiDescSize = Marshal.SizeOf(typeof(T));
                mapiMapiDescArrayPtr = Marshal.AllocHGlobal(mapiDescCollection.Count * mapiDescSize);
                var tmp = (int)mapiMapiDescArrayPtr;
                foreach (var mapiDesc in mapiDescCollection)
                {
                    Marshal.StructureToPtr(mapiDesc, (IntPtr)tmp, false);
                    tmp += mapiDescSize;
                }
                mapiDescCount = mapiDescCollection.Count;
            }
            return mapiMapiDescArrayPtr;
        }
        private static void DeallocMapiDescArray<T>(IntPtr mapiDescArrayPtr, int mapiDescArrayCount)
        {
            if (mapiDescArrayPtr != IntPtr.Zero)
            {
                int mapiDescSize = Marshal.SizeOf(typeof(T));
                var tmp = (int)mapiDescArrayPtr;
                for (int i = 0; i < mapiDescArrayCount; i++)
                {
                    Marshal.DestroyStructure((IntPtr)tmp, typeof(T));
                    tmp += mapiDescSize;
                }
                Marshal.FreeHGlobal(mapiDescArrayPtr);
            }
        }
        private static bool IsSuccess(int errorCode)
        {
            return (errorCode == Mapi32.SUCCESS_SUCCESS || errorCode == Mapi32.MAPI_USER_ABORT);
        }
        private static string GetMapiErrorMessage(int errorCode)
        {
            // This should be localized
            string error = string.Empty;
            switch (errorCode)
            {
                case Mapi32.MAPI_USER_ABORT:
                    error = "User Aborted.";
                    break;
                case Mapi32.MAPI_E_FAILURE:
                    error = "MAPI Failure.";
                    break;
                case Mapi32.MAPI_E_LOGIN_FAILURE:
                    error = "Login Failure.";
                    break;
                case Mapi32.MAPI_E_DISK_FULL:
                    error = "MAPI Disk full.";
                    break;
                case Mapi32.MAPI_E_INSUFFICIENT_MEMORY:
                    error = "MAPI Insufficient memory.";
                    break;
                case Mapi32.MAPI_E_BLK_TOO_SMALL:
                    error = "MAPI Block too small.";
                    break;
                case Mapi32.MAPI_E_TOO_MANY_SESSIONS:
                    error = "MAPI Too many sessions.";
                    break;
                case Mapi32.MAPI_E_TOO_MANY_FILES:
                    error = "MAPI too many files.";
                    break;
                case Mapi32.MAPI_E_TOO_MANY_RECIPIENTS:
                    error = "MAPI too many recipients.";
                    break;
                case Mapi32.MAPI_E_ATTACHMENT_NOT_FOUND:
                    error = "MAPI Attachment not found.";
                    break;
                case Mapi32.MAPI_E_ATTACHMENT_OPEN_FAILURE:
                    error = "MAPI Attachment open failure.";
                    break;
                case Mapi32.MAPI_E_ATTACHMENT_WRITE_FAILURE:
                    error = "MAPI Attachment Write Failure.";
                    break;
                case Mapi32.MAPI_E_UNKNOWN_RECIPIENT:
                    error = "MAPI Unknown recipient.";
                    break;
                case Mapi32.MAPI_E_BAD_RECIPTYPE:
                    error = "MAPI Bad recipient type.";
                    break;
                case Mapi32.MAPI_E_NO_MESSAGES:
                    error = "MAPI No messages.";
                    break;
                case Mapi32.MAPI_E_INVALID_MESSAGE:
                    error = "MAPI Invalid message.";
                    break;
                case Mapi32.MAPI_E_TEXT_TOO_LARGE:
                    error = "MAPI Text too large.";
                    break;
                case Mapi32.MAPI_E_INVALID_SESSION:
                    error = "MAPI Invalid session.";
                    break;
                case Mapi32.MAPI_E_TYPE_NOT_SUPPORTED:
                    error = "MAPI Type not supported.";
                    break;
                case Mapi32.MAPI_E_AMBIGUOUS_RECIPIENT:
                    error = "MAPI Ambiguous recipient.";
                    break;
                case Mapi32.MAPI_E_MESSAGE_IN_USE:
                    error = "MAPI Message in use.";
                    break;
                case Mapi32.MAPI_E_NETWORK_FAILURE:
                    error = "MAPI Network failure.";
                    break;
                case Mapi32.MAPI_E_INVALID_EDITFIELDS:
                    error = "MAPI Invalid edit fields.";
                    break;
                case Mapi32.MAPI_E_INVALID_RECIPS:
                    error = "MAPI Invalid Recipients.";
                    break;
                case Mapi32.MAPI_E_NOT_SUPPORTED:
                    error = "MAPI Not supported.";
                    break;
                case Mapi32.MAPI_E_NO_LIBRARY:
                    error = "MAPI No Library.";
                    break;
                case Mapi32.MAPI_E_INVALID_PARAMETER:
                    error = "MAPI Invalid parameter.";
                    break;
            }
            return string.Format("Error sending email. Error: {0} (code = {1}).", error, errorCode);
        }
        #endregion
    }
    public class MailAttachment
    {
        private string _attachmentFilePath;
        public MailAttachment(string attachmentFilePath)
        {
            _attachmentFilePath = attachmentFilePath;
        }
        public MapiFileDesc GetMapiFileDesc()
        {
            var mapiFileDesc = new MapiFileDesc();
            mapiFileDesc.Position = -1;
            mapiFileDesc.Path = _attachmentFilePath;
            mapiFileDesc.Name = Path.GetFileName(_attachmentFilePath);
            return mapiFileDesc;
        }
    }
    public class MailAttachment
    {
        private string _attachmentFilePath;
        public MailAttachment(string attachmentFilePath)
        {
            _attachmentFilePath = attachmentFilePath;
        }
        public MapiFileDesc GetMapiFileDesc()
        {
            var mapiFileDesc = new MapiFileDesc();
            mapiFileDesc.Position = -1;
            mapiFileDesc.Path = _attachmentFilePath;
            mapiFileDesc.Name = Path.GetFileName(_attachmentFilePath);
            return mapiFileDesc;
        }
    }
    public class MailRecipient
    {
        #region Constants and Fields
        public string _emailAddress;
        public string _displayName;
        public MailRecipientType _mailRecipientType = MailRecipientType.To;
        #endregion
        #region Constructors and Destructors
        public MailRecipient(string emailAddress, string displayName, MailRecipientType mailRecipientType)
        {
            this._emailAddress = emailAddress;
            this._displayName = displayName;
            this._mailRecipientType = mailRecipientType;
        }
        #endregion
        #region Methods
        public MapiRecipDesc GetMapiRecipDesc()
        {
            var recipDesc = new MapiRecipDesc();
            if (this._displayName == null)
            {
                recipDesc.Name = this._emailAddress;
            }
            else
            {
                recipDesc.Name = this._displayName;
                recipDesc.Address = this._emailAddress;
            }
            recipDesc.RecipientClass = (int)this._mailRecipientType;
            return recipDesc;
        }
    public enum MailRecipientType
    {
        To = 1,
        CC = 2,
        BCC = 3
    } ;
        internal class Mapi32
    {
        #region Constants and Fields
        public const int MAPI_DIALOG = 0x8;
        public const int MAPI_E_AMBIGUOUS_RECIPIENT = 21;
        public const int MAPI_E_ATTACHMENT_NOT_FOUND = 11;
        public const int MAPI_E_ATTACHMENT_OPEN_FAILURE = 12;
        public const int MAPI_E_ATTACHMENT_WRITE_FAILURE = 13;
        public const int MAPI_E_BAD_RECIPTYPE = 15;
        public const int MAPI_E_BLK_TOO_SMALL = 6;
        public const int MAPI_E_DISK_FULL = 4;
        public const int MAPI_E_FAILURE = 2;
        public const int MAPI_E_INSUFFICIENT_MEMORY = 5;
        public const int MAPI_E_INVALID_EDITFIELDS = 24;
        public const int MAPI_E_INVALID_MESSAGE = 17;
        public const int MAPI_E_INVALID_PARAMETER = 998;
        public const int MAPI_E_INVALID_RECIPS = 25;
        public const int MAPI_E_INVALID_SESSION = 19;
        public const int MAPI_E_LOGIN_FAILURE = 3;
        public const int MAPI_E_MESSAGE_IN_USE = 22;
        public const int MAPI_E_NETWORK_FAILURE = 23;
        public const int MAPI_E_NOT_SUPPORTED = 26;
        public const int MAPI_E_NO_LIBRARY = 999;
        public const int MAPI_E_NO_MESSAGES = 16;
        public const int MAPI_E_TEXT_TOO_LARGE = 18;
        public const int MAPI_E_TOO_MANY_FILES = 9;
        public const int MAPI_E_TOO_MANY_RECIPIENTS = 10;
        public const int MAPI_E_TOO_MANY_SESSIONS = 8;
        public const int MAPI_E_TYPE_NOT_SUPPORTED = 20;
        public const int MAPI_E_UNKNOWN_RECIPIENT = 14;
        public const int MAPI_LOGON_UI = 0x1;
        public const int MAPI_USER_ABORT = 1;
        public const int SUCCESS_SUCCESS = 0;
        #endregion
        #region Public Methods
        [DllImport("MAPI32.DLL", CharSet = CharSet.Ansi)]
        public static extern int MAPILogon(IntPtr hwnd, string prf, string pw, int flg, int rsv, ref IntPtr sess);
        [DllImport("MAPI32.DLL")]
        public static extern int MAPISendMail(IntPtr session, IntPtr hwnd, MapiMessage message, int flg, int rsv);
        #endregion
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class MapiFileDesc
    {
        public int Reserved;
        public int Flags;
        public int Position;
        public string Path;
        public string Name;
        public IntPtr Type = IntPtr.Zero;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class MapiMessage
    {
        public int Reserved;
        public string Subject;
        public string NoteText;
        public string MessageType;
        public string DateReceived;
        public string ConversationID;
        public int Flags;
        public IntPtr Originator = IntPtr.Zero;
        public int RecipientCount;
        public IntPtr Recipients = IntPtr.Zero;
        public int FileCount;
        public IntPtr Files = IntPtr.Zero;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class MapiRecipDesc
    {
        public int Reserved;
        public int RecipientClass;
        public string Name;
        public string Address;
        public int eIDSize;
        public IntPtr EntryID = IntPtr.Zero;
    }
