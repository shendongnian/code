    Imports System.Runtime.InteropServices
    Public Class NCForm    
      Inherits Form
    
      Public Sub New()
        Me.FormBorderStyle = FormBorderStyle.None
      End Sub
      Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)
        If m.Msg = Win32.WM_NCCALCSIZE Then        
          If m.WParam <> IntPtr.Zero Then
            Dim tmpResize As Win32.NCCALCSIZE_PARAMS = Marshal.PtrToStructure(m.LParam, GetType(Win32.NCCALCSIZE_PARAMS))
            With tmpResize.rcNewWindow
              .Left += 2
              .Top += 2
              .Right -= 2
              .Bottom -= 2
            End With
            Marshal.StructureToPtr(tmpResize, m.LParam, False)
          Else
            Dim tmpResize As Win32.RECT = Marshal.PtrToStructure(m.LParam, GetType(Win32.RECT))
            With tmpResize
              .Left += 2
              .Top += 2
              .Right -= 2
              .Bottom -= 2
            End With
            Marshal.StructureToPtr(tmpResize, m.LParam, False)
          End If
          m.Result = New IntPtr(1)
        ElseIf m.Msg = Win32.WM_NCPAINT Then
          Dim tmpDC as IntPtr = Win32.GetWindowDC(m.HWnd)
          Using tmpG As Graphics = Graphics.FromHdc(tmpDC)
            tmpG.DrawRectangle(Pens.Red, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
            tmpG.DrawRectangle(SystemPens.Window, New Rectangle(1, 1, Me.Width-3, Me.Height - 3))
          End Using
          Win32.ReleaseDC(m.HWnd, tmpDC)
        End If
      End Sub
