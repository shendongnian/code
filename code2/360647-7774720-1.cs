    using namespace System;
    using namespace System::IO;
    using namespace System::Security::Cryptography;
    using namespace System::Text;
    
    ref class Example {
    protected:
        String^ GetMD5HashFromFile(String^ fileName)
        {      
            FileStream file(fileName, FileMode::Open);
            MD5CryptoServiceProvider md5;
            array<Byte>^ retVal = md5.ComputeHash(%file);
            return Encoding::ASCII->GetString(retVal);
        }
    };
