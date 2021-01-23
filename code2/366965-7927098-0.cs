    private void AppendExceptionMessage(StringBuilder builder)
    {
        builder.Append("Message:           ");
        builder.Append(m_ExceptionInfo.Exception.Message);
        builder.Append('*');
    }
    private void AppendMethodInfo(StringBuilder builder)
    {
        builder.Append("Method:            ");
        builder.Append(m_ExceptionInfo.GetMethodName(m_ExceptionInfo.Exception));
        builder.Append('*');
    }
    body.Append("General information:");
    body.Append('*');
    body.Append('*');
    AppendExceptionMessage(body);
    AppendMethodInfo(body);
