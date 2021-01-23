    Imports System.IO
    Imports System.Xml.Serialization
    Public Class XControl
    Private _person_ID As Integer
    Private _person_UID As Guid
    'load from file
    Public Function XCRead(filename As String) As XControl
        Using sr As StreamReader = New StreamReader(filename)
            Dim xmls As New XmlSerializer(GetType(XControl))
            Return CType(xmls.Deserialize(sr), XControl)
        End Using
    End Function
    'save to file
    Public Sub XCSave(filename As String)
        Using sw As StreamWriter = New StreamWriter(filename)
            Dim xmls As New XmlSerializer(GetType(XControl))
            xmls.Serialize(sw, Me)
        End Using
    End Sub
    'all the get/set is below here
    Public Property Person_ID() As Integer
        Get
            Return _person_ID
        End Get
        Set(value As Integer)
            _person_ID = value
        End Set
    End Property
    Public Property Person_UID As Guid
        Get
            Return _person_UID
        End Get
        Set(value As Guid)
            _person_UID = value
        End Set
    End Property
    End Class
