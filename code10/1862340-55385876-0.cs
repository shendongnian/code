				[Serializable]
				public class APRegisterException : IBqlTable
				{
            				#region APRegisterRefNbr
            				[PXDBString(15, IsKey = true, IsUnicode = true, InputMask = "")]
            				[PXUIField(DisplayName = "Ref Nbr")]
    	    				[PXParent(typeof(Select<APInvoice, Where<APInvoice.refNbr, Equal<Current<APRegisterException.refNbr>>, And<APInvoice.docType, Equal<Current<APRegisterException.docType>>>>>))]
    	    				[PXDBDefault(typeof(APInvoice.refNbr))]
            				public virtual string APRegisterRefNbr { get; set; }
            				public abstract class aPRegisterRefNbr : IBqlField { }
            				#endregion
    
            				#region APDocType
            				[PXDBString(3, IsKey = true, IsUnicode = true, InputMask = "")]
            				[PXUIField(DisplayName = "Doc Type")]
            [PXDBDefault(typeof(APInvoice.docType))]
            public virtual string APDocType { get; set; }
            public abstract class aPDocType: IBqlField { }
            #endregion
            
            #region ExceptionDesc
            [PXDBString(150, IsUnicode = true, InputMask = "")]
            [PXUIField(DisplayName = "Description")]
            public virtual string ExceptionDesc { get; set; }
            public abstract class exceptionDesc : IBqlField { }
            #endregion
        
            #region ExceptionType
            [PXDBString(3, IsUnicode = true, InputMask = "", IsKey = true)]
            [PXUIField(DisplayName = "Exc. Type")]
            public virtual string ExceptionType { get; set; }
            public abstract class exceptionType : IBqlField { }
            #endregion
        
            #region ApprovedByID
            [PXDBString(15, IsUnicode = true, InputMask = "")]
            [PXUIField(DisplayName = "Approved By")]
            public virtual string ApprovedByID { get; set; }
            public abstract class approvedByID : IBqlField { }
            				#endregion
        
            				#region ApprovedDate
            				[PXDBDate()]
            				[PXUIField(DisplayName = "Approval Date")]
            				public virtual DateTime? ApprovedDate { get; set; }
            				public abstract class approvedDate : IBqlField { }
            				#endregion
				}
