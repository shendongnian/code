    RSA rsa = RSA.Create();
    rsa.ImportSubjectPublicKeyInfo(
        Convert.FromBase64String(@"
            MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAuGhYfAvWxqIwsZsO1zUN
            NyFT/3US7HGLXiW48NvYn2qNyn/9hm/BFWG901YoJAjlPTcNtMo1t8lUr2dRkc3l
            8YyP8SetWKbznerQuXYBZZy31kp8u3Wj+zQSroZsFn69FoMAMWXqhkw9woFumINe
            gw4sMtQ1S8CucX0uXJ4a2ElzoaUKp1M+MOCATDnmsXSyf/2/ERO71SpD+alDV2rE
            m5DqvEnE0t27fm7PpNeCX0XEHRvx620LooGv1Co+0w5Au37sfSjOZp1B9V0n8KFR
            6gLFY7mAZ1krZJscYgkNAPIz2QE6voBR8OVSHMnNcPH+0KLfGuNVHhaTyI4naPH+
            0QIDAQAB"),
        out _);
    // the key is loaded now.
