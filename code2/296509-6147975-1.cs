        interface IPainter
        {
            void Paint(IPaintable paintable);
        }
        interface IDecalPainter : IPainter
        {
            void Paint(IDecalPaintable paintable);
        }
        interface IPaintable
        {
            void ApplyBaseLayer(Color c);
        }
        interface IDecalPaintable : IPaintable
        {
            void ApplyDecal(HatchBrush b);
        }
        class AwesomeDecalPainter : IDecalPainter
        {
            public void Paint(IPaintable paintable)
            {
                IDecalPaintable decalPaintable = paintable as IDecalPaintable;
                if (decalPaintable != null)
                    Paint(decalPaintable);
                else
                    paintable.ApplyBaseLayer(Color.Red);
            }
            public void Paint(IDecalPaintable paintable)
            {
                paintable.ApplyBaseLayer(Color.Red);
                paintable.ApplyDecal(new HatchBrush(HatchStyle.Plaid, Color.Green));
            }
        }
