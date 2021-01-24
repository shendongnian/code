    Public Class MyControl
        Inherits WhatEverControl 'For example TextBox
        Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, keyData As System.Windows.Forms.Keys) As Boolean
              return false 'This control wont allow keydown events pass to the parent form
        End Function
    End Class
