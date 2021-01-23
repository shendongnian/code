    private bool _IsPrivate(string ipAddress)
    {
        int[] ipParts = ipAddress.Split(new String[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(s => int.Parse(s)).ToArray();
        // in private ip range
        if (ipParts[0] == 10 ||
            (ipParts[0] == 192 && ipParts[1] == 168) ||
            (ipParts[0] == 172 && (ipParts[1] >= 16 && ipParts[1] <= 31))) {
            return true;
        }
        // IP Address is probably public.
        // This doesn't catch some VPN ranges like OpenVPN and Hamachi.
        return false;
    }
