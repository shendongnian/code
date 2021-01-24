    SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy
    {
        // Expiration is in 12 hours.
        SharedAccessExpiryTime = DateTime.UtcNow.AddHours(12),
        Permissions = permissions
    };
