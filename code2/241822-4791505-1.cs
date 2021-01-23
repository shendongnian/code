    <DataContract()>
    <MetadataType(GetType(POCOAuthorizedkeys.POCOAuthorizedkeysMetaData))>
    Public Class POCOAuthorizedkeys
    
        <DataMember()>
        <DisplayName("Id")>
        Public Property Id As Integer
        <DataMember()>
        <DisplayName("IdPackage")>
        Public Property IdPackage As Integer
        <DataMember()>
        <DisplayName("AuthorizedKey")>
        Public Property AuthorizedKey As String
        <DataMember()>
        <DisplayName("IdUnthrustedClient")>
        Public Property IdUnthrustedClient As Nullable(Of Integer)
    
     End Class
