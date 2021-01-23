    private static bool TryConnect(DdeClient client)
    {
        try {
            client.Connect();
            return true;
        } catch (DdeException) {
            try {
                client.Connect();
                return true;
            } catch (DdeException) {
                return false;
            }
        }
    }
