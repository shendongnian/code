    .class public interface abstract auto ansi IDataErrorInfo
    {
        .custom instance void [mscorlib]System.Reflection.DefaultMemberAttribute::.ctor(string) = { string('Item') }
        .property instance string Error
        {
            .get instance string System.ComponentModel.IDataErrorInfo::get_Error()
        }
    
        .property instance string Item
        {
            .get instance string System.ComponentModel.IDataErrorInfo::get_Item(string)
        }
    
    }
