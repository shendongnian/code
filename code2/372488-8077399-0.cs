    Imports Microsoft.VisualBasic
    Imports System
    Imports System.Collections
    Imports System.Collections.Generic
    Imports System.Data
    Imports System.Diagnostics
    Imports Twitterizer
    
    Public Class BasePage
    	Inherits System.Web.UI.Page
    
    	Protected Sub DisplayAlert(ByVal msg As String)
    		ClientScript.RegisterStartupScript(Me.GetType(), Guid.NewGuid().ToString(), String.Format("alert('{0}');", msg.Replace("'", "\'").Replace(Constants.vbCrLf, "\n")), True)
    	End Sub
    
    	Protected Function GetCachedAccessToken() As OAuthTokens
    		If Session("AccessToken") IsNot Nothing Then
    			Return CType(Session("AccessToken"), OAuthTokens)
    		Else
    			Return Nothing
    		End If
    	End Function
    
    	Public Function GetCachedUserId() As ULong
    		If Session("GetCachedUserId") IsNot Nothing Then
    			Return Convert.ToUInt64(Session("GetCachedUserId"))
    		Else
    			Return ULong.MinValue
    		End If
    	End Function
    
    	Protected Sub CreateCachedAccessToken(ByVal requestToken As String)
    		Dim ConsumerKey As String = ConfigurationManager.AppSettings("ConsumerKey")
    		Dim ConsumerSecret As String = ConfigurationManager.AppSettings("ConsumerSecret")
    
    		Dim responseToken As OAuthTokenResponse = OAuthUtility.GetAccessToken(ConsumerKey, ConsumerSecret, requestToken)
    
    		'Cache the UserId
    		Session("GetCachedUserId") = responseToken.UserId
    
    		Dim accessToken As New OAuthTokens()
    		accessToken.AccessToken = responseToken.Token
    		accessToken.AccessTokenSecret = responseToken.TokenSecret
    		accessToken.ConsumerKey = ConsumerKey
    		accessToken.ConsumerSecret = ConsumerSecret
    
    		Session("AccessToken") = accessToken
    	End Sub
    
    	Protected Function GetTwitterAuthorizationUrl() As String
    		Dim ConsumerKey As String = ConfigurationManager.AppSettings("ConsumerKey")
    		Dim ConsumerSecret As String = ConfigurationManager.AppSettings("ConsumerSecret")
    
    		Dim reqToken As OAuthTokenResponse = OAuthUtility.GetRequestToken(ConsumerKey, ConsumerSecret)
    		Return "https://twitter.com/oauth/authorize?oauth_token=" & reqToken.Token
    	End Function
    End Class
