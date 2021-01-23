    Public Shared ThatModule As IHttpModule = New WebServiceAuthenticationModule()
    ' http://www.west-wind.com/weblog/posts/44979.aspx
    Public Overrides Sub Init()
        MyBase.Init()
        ThatModule.Init(Me)
    End Sub
