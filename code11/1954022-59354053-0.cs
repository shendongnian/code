    NetTcpBinding binding = new NetTcpBinding();
----------
    NetTcpBinding binding = new NetTcpBinding();
                binding.Security.Mode = SecurityMode.Message;
                binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
