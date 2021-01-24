public static class InlineMappingExtensions
    {
        public static void EnableInlineMapping(this IMapperConfigurationExpression cfg)
        {
            cfg.ForAllMaps((t, i) =>
            {
                i.AfterMap((s, d, ctx) =>
                    {
                        ctx.ApplyInlineMap(s, d);
                    }
                );
            });
        }
        public static IMappingOperationOptions OnMap<TSrc, TDst>(this IMappingOperationOptions opts,
            Action<TSrc, TDst> resolve)
        {
            var srcTypeName = typeof(TSrc);
            var dstTypeName = typeof(TDst);
            var ctxKey = $"OnMap_{srcTypeName}_{dstTypeName}";
            opts.Items.Add(ctxKey, resolve);
            return opts;
        }
        private static void ApplyInlineMap(this ResolutionContext opts, object src, object dst)
        {
            if (src == null)
            {
                return;
            }
            if (dst == null)
            {
                return;
            }
            var srcTypeName = src.GetType();
            var dstTypeName = dst.GetType();
            var ctxKey = $"OnMap_{srcTypeName}_{dstTypeName}";
            if (!opts.Items.TryGetValue(ctxKey, out var inlineMap))
            {
                return;
            }
            var act = inlineMap as Delegate;
            act?.DynamicInvoke(src, dst);
        }
    }
To enable it:
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.ValidateInlineMaps = false;
                cfg.EnableInlineMapping();
            });
Sample of usage:
// read data from external sources
            var names = new Dictionary<int, string>
            {
                { 10, "FullName-10" },
                { 20, "FullName-20" },
            };
            Action<UserDto, UserViewModel> mapA = (s, d) =>
            {
                if (names.TryGetValue(s.UserId, out var name))
                {
                    d.FullName = name;
                }
            };
            Action<UserGroupDto, UserGroup> mapB = (s, d) =>
            {
                if (DateTime.Now.Ticks > 0)
                {
                    d.Users = null;
                }
            };
            var dst = Mapper.Map<UserGroupDto, UserGroup>(src, opt => opt.OnMap(mapA).OnMap(mapB));
