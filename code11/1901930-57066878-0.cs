        var filter = TableQuery.GenerateFilterCondition("container", QueryComparisons.Equal, container);
    
        var entity = (await cloudTable.ExecuteQuerySegmentedAsync(new TableQuery<SftpServerConnectionsModel>().Where(filter), null)).Single();
    
        return new ConnectionInfo(entity.uri, entity.user, new AuthenticationMethod[] { new PasswordAuthenticationMethod(entity.user,entity.password)});
    }
