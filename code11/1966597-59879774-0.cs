    var result = from item in volumeList.Items
        select new
        {
            MetadataName = item.Metadata?.Name,
            Namespace = item.Metadata?.NamespaceProperty,
            Age = item.Metadata?.CreationTimestamp,
            Type = item.Spec?.Type,
            All = item?.Status,
            Ip = item.Status?.LoadBalancer?.Ingress.Select(x => x.Ip)
        };
