    CodeMemberField dynamicMember = new CodeMemberField ( );
    dynamicMember.Name = dynamicMemberName;
    dynamicMember.Attributes = MemberAttributes.Private;
    dynamicMember.Type = new CodeTypeReference ( "dynamic" );
    operationCodeType.Members.Add ( dynamicMember );
