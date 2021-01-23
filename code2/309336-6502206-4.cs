    Public Property Get MyDate() As Variant
        MyDate = myclassinstance.GetPropertyValue("MyDate")
    End Property
    Public Property Set MyDate(value as Variant)
        myclassinstance.SetPropertyValue "MyDate", value
    End Property
