    btn.TouchUpInside += delegate {
        UIView.Animate (0.5f, delegate {
            lbl.Alpha = 0.0f;
        }, delegate {
            UIView.Animate (0.5f, delegate {
                lbl.Alpha = 1.0f;
            });
        });
    };
