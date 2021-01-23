    return new XElement("EffectFile",
        new XElement("Effects",
            this.Effects
                .Select(e => new XElement("Effect", e.EffectType))
                .Concat(this.Opacity > 0.0f
                    ? new[] { new XElement("Opacity", this.Opacity) }
                    : Enumerable.Empty<XElement>()
                    )
            )
        )
        .ToString();
