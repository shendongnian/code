using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
namespace ConsoleApp1
{
    class Program
    {
        // For testing ...
        private static Random random = new Random();
        public static string GetRandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var result = new string(
                Enumerable.Repeat(chars, length)
                            .Select(s => s[random.Next(s.Length)])
                            .ToArray());
            return result;
        }
        // 
        static void Main(string[] args)
        {
            string password = "pA5w0rd";
            using (StreamWriter file = new StreamWriter(@"data.txt"))
            {
                for (int num = 1; num < 2048; num++)
                {
                    string random_s = GetRandomString(num);
                    string test_enc = encodeText(random_s, password);
                    string test_dec = decodeText(test_enc, password);
                    file.WriteLine(random_s);
                    file.WriteLine(test_enc);
                }
            }
        }
        // Static IV
        static byte[] iv = new byte[] { 0xf0, 0xe1, 0xd2, 0xc3, 0xb4, 0xa5, 0x96, 0x87, 0x78, 0x69, 0x5a, 0x4b, 0x3c, 0x2d, 0x5e, 0xaf };
        // Decrypt text using key(password)
        static string decodeText(string hexEncodedText, string key)
        {
            MD5 md5 = MD5.Create();
            byte[] keyBytes = Encoding.ASCII.GetBytes(key);
            byte[] md5Bytes = md5.ComputeHash(keyBytes);
            int length = hexEncodedText.Length;
            int encryptionLength = getAlignedSize(length, 16);
            byte[] encodedText = GetStringToBytes(hexEncodedText);
            Array.Resize(ref encodedText, encryptionLength);
            byte[] plainTextBytes;
            using (var aes = new AesManaged
            {
                KeySize = 128,
                BlockSize = 128,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.Zeros
            })
            {
                using (var decrypter = aes.CreateDecryptor(md5Bytes, iv))
                using (var plainTextStream = new MemoryStream())
                {
                    using (var decrypterStream = new CryptoStream(plainTextStream, decrypter, CryptoStreamMode.Write))
                    using (var binaryWriter = new BinaryWriter(decrypterStream, Encoding.Unicode))
                    {
                        binaryWriter.Write(encodedText);
                    }
                    plainTextBytes = plainTextStream.ToArray();
                }
            }
            string utf8String = String.Empty;
            byte[] utf8Bytes = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, plainTextBytes);
            utf8String = Encoding.UTF8.GetString(utf8Bytes);
            int index = utf8String.IndexOf('\0');
            if (index >= 0)
            {
                utf8String = utf8String.Remove(index);
            }
            return utf8String;
        }
        // Encrypt text using key(password)
        static string encodeText(string rawText, string key)
        {
            MD5 md5 = MD5.Create();
            byte[] keyBytes = Encoding.ASCII.GetBytes(key);
            byte[] md5Bytes = md5.ComputeHash(keyBytes);
            byte[] inputData = Encoding.Unicode.GetBytes(rawText + "\0");
            int encryptionLength = getAlignedSize(inputData.Length, 16);
            Array.Resize(ref inputData, encryptionLength);
            byte[] cipherText;
            using (var aes = new AesManaged
            {
                KeySize = 128,
                BlockSize = 128,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.Zeros
            })
            {
                using (var encrypter = aes.CreateEncryptor(md5Bytes, iv))
                using (var cipherStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(cipherStream, encrypter, CryptoStreamMode.Write))
                    using (var binaryWriter = new BinaryWriter(cryptoStream, Encoding.Unicode))
                    {
                        binaryWriter.Write(inputData);
                    }
                    cipherText = cipherStream.ToArray();
                }
            }
            return GetBytesToString(cipherText);
        }
        // Align data
        public static int getAlignedSize(int currSize, int alignment)
        {
            int padding = (alignment - currSize % alignment) % alignment;
            return currSize + padding;
        }
        // Convert string to HEX
        public static byte[] GetStringToBytes(string value)
        {
            SoapHexBinary shb = SoapHexBinary.Parse(value);
            return shb.Value;
        }
        // Convert HEX to string
        public static string GetBytesToString(byte[] value)
        {
            SoapHexBinary shb = new SoapHexBinary(value);
            return shb.ToString();
        }
    }
}
Qt/C++ version
#include <QCoreApplication>
#include <QFile>
#include <QTextStream>
#include <QCryptographicHash>
#include <QDebug>
#include "aes/aes.hpp"
namespace Encryption {
   const uint8_t iv[] = { 0xf0, 0xe1, 0xd2, 0xc3, 0xb4, 0xa5, 0x96, 0x87, 0x78, 0x69, 0x5a, 0x4b, 0x3c, 0x2d, 0x5e, 0xaf };
   inline int getAlignedSize(int currSize, int alignment) {
      int padding = (alignment - currSize % alignment) % alignment;
      return currSize + padding;
   }
   inline static QString encodeText(const QString &rawText, const QString &key) {
      QCryptographicHash hash(QCryptographicHash::Md5);
      hash.addData(key.toUtf8());
      QByteArray keyData = hash.result();
      const ushort *rawData = rawText.utf16();
      void *rawDataVoid = (void*)rawData;
      const char *rawDataChar = static_cast<const char*>(rawDataVoid);
      QByteArray inputData;
      inputData.append(rawDataChar, rawText.size() * sizeof(QChar) + 1);
      const int length = inputData.size();
      int encryptionLength = getAlignedSize(length, 16);
      Q_ASSERT(encryptionLength % 16 == 0 && encryptionLength >= length);
      inputData.resize(encryptionLength);
      for (int i = length; i < encryptionLength; i++) { inputData[i] = 0; }
      struct AES_ctx ctx;
      AES_init_ctx_iv(&ctx, (const uint8_t*)keyData.data(), iv);
      AES_CBC_encrypt_buffer(&ctx, (uint8_t*)inputData.data(), encryptionLength);
      QString hex = QString::fromLatin1(inputData.toHex());
      return hex;
   }
   inline static QString decodeText(const QString &hexEncodedText, const QString &key) {
      QCryptographicHash hash(QCryptographicHash::Md5);
      hash.addData(key.toUtf8());
      QByteArray keyData = hash.result();
      const int length = hexEncodedText.size();
      int encryptionLength = getAlignedSize(length, 16);
      QByteArray encodedText = QByteArray::fromHex(hexEncodedText.toLatin1());
      const int encodedOriginalSize = encodedText.size();
      Q_ASSERT(encodedText.length() <= encryptionLength);
      encodedText.resize(encryptionLength);
      for (int i = encodedOriginalSize; i < encryptionLength; i++) { encodedText[i] = 0; }
      struct AES_ctx ctx;
      AES_init_ctx_iv(&ctx, (const uint8_t*)keyData.data(), iv);
      AES_CBC_decrypt_buffer(&ctx, (uint8_t*)encodedText.data(), encryptionLength);
      encodedText.append("\0\0");
      void *data = encodedText.data();
      const ushort *decodedData = static_cast<ushort *>(data);
      QString result = QString::fromUtf16(decodedData, -1);
      return result;
   }
}
int main(int argc, char *argv[])
{
   QCoreApplication a(argc, argv);
   QFile inputFile("data.txt");
   if (inputFile.open(QIODevice::ReadOnly))
   {
      QTextStream in(&inputFile);
      while (!in.atEnd())
      {
         QString random_s = in.readLine();
         QString test_enc = in.readLine();
         QString qt_enc = Encryption::encodeText(random_s, "pA5w0rd").toUpper();
         if(qt_enc != test_enc)
         {
            qDebug() << "Invalid decryption";
         }
      }
      inputFile.close();
   }
   return a.exec();
}
