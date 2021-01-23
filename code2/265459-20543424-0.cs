    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure LV_ITEM
        Public Mask As UInteger
        Public Index As Integer
        Public SubIndex As Integer
        Public State As Integer
        Public StateMask As IntPtr
        Public Text As String
        Public TextLength As Integer
        Public ImageIndex As Integer
        Public LParam As IntPtr
    End Structure
