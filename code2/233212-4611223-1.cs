    Public Class ValidateCaptchaAttribute : Inherits ActionFilterAttribute
        Private Const CHALLENGE_FIELD_KEY As String = "recaptcha_challenge_field"
        Private Const RESPONSE_FIELD_KEY As String = "recaptcha_response_field"
        Public Overrides Sub OnActionExecuting(ByVal filterContext As ActionExecutingContext)
            If IsNothing(filterContext.HttpContext.Request.Form(CHALLENGE_FIELD_KEY)) Then
                ' this will push the result value into a parameter in our Action
                filterContext.ActionParameters("CaptchaIsValid") = True
                Return
            End If
            Dim captchaChallengeValue = filterContext.HttpContext.Request.Form(CHALLENGE_FIELD_KEY)
            Dim captchaResponseValue = filterContext.HttpContext.Request.Form(RESPONSE_FIELD_KEY)
            Dim captchaValidtor = New RecaptchaValidator() With {.PrivateKey = "xxxxx",
                                                                           .RemoteIP = filterContext.HttpContext.Request.UserHostAddress,
                                                                           .Challenge = captchaChallengeValue,
                                                                           .Response = captchaResponseValue}
            Dim recaptchaResponse = captchaValidtor.Validate()
            ' this will push the result value into a parameter in our Action
            filterContext.ActionParameters("CaptchaIsValid") = recaptchaResponse.IsValid
            MyBase.OnActionExecuting(filterContext)
        End Sub
